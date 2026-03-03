using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Command
{
    public class ActualizarPersonaCommand : IRequestHandler<ActualizarPersonaViewModel, CommandResponseViewModel>
    {
        readonly private IPersonaRepository _IPersonaRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarPersonaCommand(IUsuarioRolRepository IIUsuarioRolRepository, IPersonaRepository IPersonaRepository)
        {
            _IPersonaRepository = IPersonaRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(ActualizarPersonaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
               var idUsuarioPerfil= await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (request.idPersona == 0) throw new MreException(Constantes.MensajesError.EX_PERSONA_ID_REQUIRED);
                if (request.idTipoDocumento == 0) throw new MreException(Constantes.MensajesError.EX_PERSONA_TIPO_DOCUMENTO_REQUIRED);
                if (string.IsNullOrEmpty(request.numeroDocumento)) throw new MreException(Constantes.MensajesError.EX_PERSONA_DOCUMENTO_REQUIRED);
                if (string.IsNullOrEmpty(request.nombres)) throw new MreException(Constantes.MensajesError.EX_PERSONA_NOMBRE_REQUIRED);
                if (string.IsNullOrEmpty(request.apellidoPaterno)) throw new MreException(Constantes.MensajesError.EX_PERSONA_APELLIDO_PATERNO_REQUIRED);
                //if (string.IsNullOrEmpty(request.apellidoMaterno)) throw new MreException(Constantes.MensajesError.EX_PERSONA_APELLIDO_MATERNO_REQUIRED);
                if (request.idEstadoCivil == 0) throw new MreException(Constantes.MensajesError.EX_PERSONA_ESTADO_CIVIL_REQUIRED);
                if (request.idPaisNacimiento == 0) throw new MreException(Constantes.MensajesError.EX_PERSONA_PAIS_NACIMIENTO_REQUIRED);
                if (string.IsNullOrEmpty(request.correo) || !IsValidEmail(request.correo)) throw new MreException(Constantes.MensajesError.EX_VALIDATE_CORREO_GENERAL);
                if (request.sexo == null || request.sexo == "0" || request.sexo == "") throw new MreException(Constantes.MensajesError.EX_PERSONA_SEXO_REQUIRED);

                var valDocumento = await _IPersonaRepository.ObtenerPersonaVal(new ObtenerPersonaValRequestDTO()
                {
                    numeroDocumento = request.numeroDocumento,
                    idTipoDocumento = request.idTipoDocumento
                });
                if (valDocumento != null && valDocumento.idPersona != request.idPersona) throw new MreException(Constantes.MensajesError.EX_PERSONA_DOCUMENTO_DP);


                var entity = PersonaMap.MaptoEntity(request);
                entity.usuarioModificacion = idUsuarioPerfil.ToString();


                var result = await _IPersonaRepository.Actualizar(entity);
                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_PERSONA_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };
            }
            catch (System.Exception ex)
            {

                throw;
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
