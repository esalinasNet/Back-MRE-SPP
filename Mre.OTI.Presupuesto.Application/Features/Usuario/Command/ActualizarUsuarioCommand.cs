using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Command
{
    public class ActualizarUsuarioCommand : IRequestHandler<ActualizarUsuarioViewModel, CommandResponseViewModel>
    {
        readonly private IUsuarioRepository _IUsuarioRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarUsuarioCommand(IUsuarioRolRepository IIUsuarioRolRepository, IUsuarioRepository IUsuarioRepository)
        {
            _IUsuarioRepository = IUsuarioRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(ActualizarUsuarioViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                var idUsuarioRol=await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (request.idPersona == 0) throw new MreException(Constantes.MensajesError.EX_USUARIO_ID_PERSONA_REQUIRED);
                if (string.IsNullOrEmpty(request.usuarioNT) && request.isMre==1) throw new MreException(Constantes.MensajesError.EX_USUARIO_USUARIO_NT_REQUIRED);
                //if (string.IsNullOrEmpty(request.claveNT) && request.isMre == 1) throw new MreException(Constantes.MensajesError.EX_USUARIO_CLAVE_NT_REQUIRED);

                if ((string.IsNullOrEmpty(request.correo) || !IsValidEmail(request.correo))&& request.isMre==0) throw new MreException(Constantes.MensajesError.EX_VALIDATE_CORREO_GENERAL);
                var entity = UsuarioMap.MaptoEntity(request);

                entity.usuarioModificacion = idUsuarioRol.ToString();

              
                var valIdPersona= await _IUsuarioRepository.ObtenerUsuarioVal(new ObtenerUsuarioValRequestDTO()
                {
                    idPersona = request.idPersona,
                    fraseEncriptacion=Constantes.SISTEMA.KEY_ENCRYPT_LOGIN
                });
                if (valIdPersona != null && valIdPersona.idUsuario != request.idUsuario) throw new MreException(Constantes.MensajesError.EX_USUARIO_NUMERO_DOCUMENTO_DP);

                if (!string.IsNullOrEmpty(request.correo))
                {
                    var valCorreo = await _IUsuarioRepository.ObtenerUsuarioVal(new ObtenerUsuarioValRequestDTO()
                    {
                        correo = request.correo,
                        fraseEncriptacion = Constantes.SISTEMA.KEY_ENCRYPT_LOGIN
                    });
                    if (valCorreo != null) throw new MreException(Constantes.MensajesError.EX_USUARIO_CORREO_DP);

                }

                if (!string.IsNullOrEmpty(request.usuarioNT))
                {
                    var valUsuarioNT = await _IUsuarioRepository.ObtenerUsuarioVal(new ObtenerUsuarioValRequestDTO()
                    {
                        usuarioNT = request.usuarioNT,
                        fraseEncriptacion = Constantes.SISTEMA.KEY_ENCRYPT_LOGIN
                    });
                    if (valUsuarioNT != null && valIdPersona.idUsuario != request.idUsuario) throw new MreException(Constantes.MensajesError.EX_USUARIO_NT_DP);

                }
                entity.fraseEncriptacion = Constantes.SISTEMA.KEY_ENCRYPT_LOGIN;

                var result = await _IUsuarioRepository.Actualizar(entity);


                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_USUARIO_UPDATE_OK : Constantes.MensajesError.EX_USUARIO_UPDATE_ERROR,
                    result = result
                };
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
