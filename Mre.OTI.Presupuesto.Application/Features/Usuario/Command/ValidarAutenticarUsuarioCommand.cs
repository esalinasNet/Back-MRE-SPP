using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mre.OTI.Presupuesto.Domain.Setting;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Command
{
    public class ValidarAutenticarUsuarioCommand : IRequestHandler<ValidarAutenticarUsuarioViewModel, bool>
    {

        // readonly private IUsuarioRepository _IUsuarioRepository;
        readonly private JWTSettings _JWTSettings;

        public ValidarAutenticarUsuarioCommand(IOptions<JWTSettings> JWTSettings
                /*, IUsuarioRepository IIUsuarioRepository
                 * */)
        {

            _JWTSettings = JWTSettings.Value;
            //  _IUsuarioRepository = IIUsuarioRepository;
        }

        public async Task<bool> Handle(ValidarAutenticarUsuarioViewModel request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_JWTSettings.Key);
            try
            {

                tokenHandler.ValidateToken(request.token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = _JWTSettings.Issuer,
                    ValidAudience = _JWTSettings.Audience,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTSettings.Key))

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = jwtToken.Claims.First(x => x.Type == "jti").Value;

                // return account id from JWT token if validation successful
                return true;
            }
            catch
            {
                // return null if validation fails
                return false;
            }
        }

    }
}
