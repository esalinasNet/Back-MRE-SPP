using iTextSharp.text;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Repositories.Services;
using Mre.OTI.Presupuesto.Application.Responses.Autentication;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Presupuesto.Domain.Setting;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Org.BouncyCastle.Security.Certificates;
using System.DirectoryServices;
//using System.DirectoryServices;


namespace Mre.OTI.Presupuesto.Application.Features.Autenticacion.Command
{
    public class AutenticarUsuarioCommand : IRequestHandler<AutenticarUsuarioViewModel, AutenticationViewModel>
    {

        readonly private IUsuarioRepository _IUsuarioRepository;
        readonly private JWTSettings _JWTSettings;
        readonly private LDAPSettings _LDAPSettings;
        readonly private LoginSettings _LoginSettings;
        readonly private ILogSessionRepository _ILogSessionRepository;
        readonly private GoogleReCaptchaSettings _GoogleReCaptchaSettings;
        const string K_CODIGO_SISTEMA = "B97263B0-DE79-4C95-AD3E-1F3B9185879B";

        public AutenticarUsuarioCommand(IOptions<JWTSettings> JWTSettings,
            IUsuarioRepository IIUsuarioRepository,
            IOptions<LDAPSettings> LDAPSettings,
            IOptions<LoginSettings> LoginSettings,
            ILogSessionRepository ILogSessionRepository,
            IOptions<GoogleReCaptchaSettings> googleReCaptchaSettings
        )
        {
            _LoginSettings = LoginSettings.Value;
            _JWTSettings = JWTSettings.Value;
            _IUsuarioRepository = IIUsuarioRepository;
            _LDAPSettings = LDAPSettings.Value;
            _ILogSessionRepository = ILogSessionRepository;
            _GoogleReCaptchaSettings = googleReCaptchaSettings.Value;
        }

        public async Task<AutenticationViewModel> Handle(AutenticarUsuarioViewModel request, CancellationToken cancellationToken)
        {
            try
            {
              
                await ReCaptchaValidate(request);

                if (string.IsNullOrEmpty(request.userName)) throw new MreException(Constantes.MensajesError.EX_LOGIN_USERNT_REQUIRED);
                if (string.IsNullOrEmpty(request.password)) throw new MreException(Constantes.MensajesError.EX_LOGIN_PWD_REQUIRED);

                /*
                 ACA VALIDAR EL LOGIN CON EL ACTIVE DIRECTORY.
                */




                if (_LoginSettings.NTRequired)
                {
                    DirectoryEntry objUser = null;
                    objUser = ActiveDirectoryValidator(request.userName, request.password);
                    if (objUser == null) throw new MreException(Constantes.MensajesError.EX_LOGIN_USERNT_NOT_FOUND);

                }



                var resultLogin = await _IUsuarioRepository.ObtenerUsuarioLogin(new ObtenerUsuarioLoginRequestDTO
                {
                    usuarioNT = request.userName,
                    claveNT = request.password,
                    fraseEncriptacion = Constantes.SISTEMA.KEY_ENCRYPT_LOGIN,
                    codigoSistema = K_CODIGO_SISTEMA /*param sistema seguridad*/
                });

                var entityLog = LogSessionMap.MaptoEntity(request);

                if (!resultLogin.Any())
                {
                    entityLog.CODIGO_SISTEMA = K_CODIGO_SISTEMA;
                    entityLog.ORIGEN_LOGIN = Constantes.OrigenLogin.BACKOFFICE;
                    entityLog.RESULTADO = Constantes.ResultadoLogin.ERROR;
                    entityLog.ORIGEN_DISPOSITIVO = request.dispositivo;
                    entityLog.COMEMTARIOS = string.Format(@"{0}-{1}", Constantes.MensajesError.EX_LOGIN_USERBD_NOT_FOUND, Constantes.AccionLogin.LOGIN);

                    var logSessionError = await _ILogSessionRepository.Guardar(entityLog);

                    throw new MreException(Constantes.MensajesError.EX_LOGIN_USERBD_NOT_FOUND);
                }
                var roles = resultLogin.Select(x =>
                new RolResponse
                {
                    descripcionRol = x.descripcionRol,
                    codigoRol = x.codigoRol,
                    idUsuarioRol = EncryptionPassportHandler.Encrypt(x.idUsuarioRol.ToString(), Constantes.SISTEMA.KEY_ENCRYPT),
                    idRol = UrlEncryptationSecurity.Encrypt(Convert.ToString(x.idRol)),
                    idSistema = UrlEncryptationSecurity.Encrypt(x.codigoSistema)
                });
           

                var userLogged = resultLogin.FirstOrDefault();

                var usuario = new RegisterRequest
                {
                    userName = userLogged.usuarioNT,
                    correo = userLogged.correo,
                    descripcionRol = userLogged.descripcionRol,
                    ipAcceso = request.ipAcceso,
                    idUsuarioRol = userLogged.idUsuarioRol,
                    idRol = UrlEncryptationSecurity.Encrypt(Convert.ToString(userLogged.idRol)),
                    idSistema = UrlEncryptationSecurity.Encrypt(userLogged.codigoSistema)
                };

                var claimns = new[]
                {
                  new Claim(JwtRegisteredClaimNames.Sub, usuario.userName),
                  new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Email,usuario.correo),
                  new Claim("uid",usuario.idUsuarioRol.ToString()),
                  new Claim("ip", usuario.ipAcceso),
                  new Claim(ClaimTypes.Role, roles.FirstOrDefault().codigoRol.ToString())

             };
                //.Union(roleClaims);


                var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTSettings.Key));
                var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _JWTSettings.Issuer,
                    audience: _JWTSettings.Audience,
                    claims: claimns,
                    expires: DateTime.Now.AddMinutes(_JWTSettings.DurationInMinutes),
                    signingCredentials: signingCredentials
                );


                var idUsuarioRolStrEncryp = EncryptionPassportHandler.Encrypt(userLogged.idUsuarioRol.ToString(), Constantes.SISTEMA.KEY_ENCRYPT);

                string idur = usuario.idUsuarioRol.ToString();
                var response = new AutenticationViewModel
                {
                    JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    idUsuarioRolStr = idUsuarioRolStrEncryp,
                    correo = usuario.correo,
                    nombreUsuario = usuario.userName,
                    descripcionRol = usuario.descripcionRol,
                    idRol = usuario.idRol,
                    codigoRol = userLogged.codigoRol,
                    isVerified = true,
                    message = Constantes.MensajesOK.M01_LOGIN_OK,
                    roles = roles,
                    idSistema = usuario.idSistema
                };

                var refreshToken = generateRefreshToken(usuario.ipAcceso);
                response.refreshToken = refreshToken.token;

                entityLog.ORIGEN_LOGIN = Constantes.OrigenLogin.BACKOFFICE;
                entityLog.RESULTADO = Constantes.ResultadoLogin.CORRECTO;
                entityLog.ORIGEN_DISPOSITIVO = request.dispositivo;
                entityLog.TOKEN = response.JWToken;
                entityLog.COMEMTARIOS = string.Format(@"{0}-{1}", Constantes.MensajesOK.M01_LOGIN_OK, Constantes.AccionLogin.LOGIN);
                entityLog.CODIGO_SISTEMA = K_CODIGO_SISTEMA;/**/

                var logSession = await _ILogSessionRepository.Guardar(entityLog);

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    

        private RefreshToken generateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                token = RandomTokenString(),
                Expires = DateTime.Now.AddDays(7),
                created = DateTime.Now,
                createdByIp = ipAddress
            };
        }
        private string RandomTokenString()
        {
            using var rngCryptoServideProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];

            rngCryptoServideProvider.GetBytes(randomBytes);

            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
        async Task ReCaptchaValidate(AutenticarUsuarioViewModel request)
        {
            if (_GoogleReCaptchaSettings.Enabled)
            {
                var validateRecaptcha = await Recursos.VerifyTokenReCaptcha(request.tokenCaptcha, _GoogleReCaptchaSettings);
                if (validateRecaptcha == null)
                {
                    var entityLog = LogSessionMap.MaptoEntity(request);
                    entityLog.ORIGEN_LOGIN = Constantes.OrigenLogin.BACKOFFICE;
                    entityLog.RESULTADO = Constantes.ResultadoLogin.ERROR;
                    entityLog.ORIGEN_DISPOSITIVO = request.dispositivo;
                    entityLog.COMEMTARIOS = string.Format(@"validateRecaptcha no se logró inicializar-{0}", Constantes.AccionLogin.LOGIN);
                    entityLog.CODIGO_SISTEMA = K_CODIGO_SISTEMA;/**/
                    _ = await _ILogSessionRepository.Guardar(entityLog);

                    throw new MreException("NO SE PUDO VALIDAR EL CAPTCHA v3");
                }
                else
                {
                    if (!validateRecaptcha.Success)
                    {
                        var entityLog = LogSessionMap.MaptoEntity(request);
                        entityLog.ORIGEN_LOGIN = Constantes.OrigenLogin.BACKOFFICE;
                        entityLog.RESULTADO = Constantes.ResultadoLogin.ERROR;
                        entityLog.ORIGEN_DISPOSITIVO = request.dispositivo;
                        entityLog.COMEMTARIOS = string.Format(@"{0}-{1}", validateRecaptcha.Error, Constantes.AccionLogin.LOGIN);
                        entityLog.CODIGO_SISTEMA = K_CODIGO_SISTEMA;
                        _ = await _ILogSessionRepository.Guardar(entityLog);

                        throw new MreException(validateRecaptcha.Error.ToUpper());

                    }
                }
            }
        }
        DirectoryEntry ActiveDirectoryValidator(String txtUser, String txtpwd)
        {

            DirectoryEntry objUser;
            try
            {

                var strProtocolo = _LDAPSettings.ProtocoloAcceso;
                var strNombreDominioInferior = _LDAPSettings.NombreDominioInferior;
                var strDominioSuperiorA = _LDAPSettings.DominioSuperiorA;
                var strDominioSuperiorB = _LDAPSettings.DominioSuperiorB;
                var strDominioCompleto = strNombreDominioInferior + "." + strDominioSuperiorA + "." + strDominioSuperiorB;

                var strDominio = strProtocolo + "://" + strDominioCompleto + "/DC=" + strNombreDominioInferior + ", DC=" + strDominioSuperiorA + ", DC=" + strDominioSuperiorB;
                DirectoryEntry objDirectoryEntry = new DirectoryEntry(strDominio, txtUser, txtpwd, AuthenticationTypes.Secure);

                DirectorySearcher objDirectorySearcher = new DirectorySearcher(objDirectoryEntry);
                SearchResult objSearchResult;
                objDirectorySearcher.Filter = string.Format("(SAMAccountName={0})", txtUser);
                objSearchResult = objDirectorySearcher.FindOne();

                if (objSearchResult != null)
                { objUser = objSearchResult.GetDirectoryEntry(); }
                else
                {
                    throw new MreException(Constantes.MensajesError.EX_LOGIN_USERNT_NOT_FOUND_AD);

                }

                return objUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        private class RefreshToken
        {
            public int id { get; set; }
            public string token { get; set; }

            public DateTime Expires { get; set; }

            public bool isExpired => DateTime.Now >= Expires;
            public DateTime created { get; set; }
            public string createdByIp { get; set; }

            public DateTime? revoked { get; set; }
            public string revokedByIp { get; set; }

            public string replacedByToken { get; set; }

            public bool isActive => revoked == null && !isExpired;

        }
    }
   

}
