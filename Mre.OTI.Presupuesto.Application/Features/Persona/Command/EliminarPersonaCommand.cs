using MediatR;
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
using Org.BouncyCastle.Security.Certificates;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Command
{
    public class EliminarPersonaCommand : IRequestHandler<EliminarPersonaViewModel, CommandResponseViewModel>
    {
        readonly private IPersonaRepository _IPersonaRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarPersonaCommand(IUsuarioRolRepository IIUsuarioRolRepository, IPersonaRepository IPersonaRepository)
        {
            _IPersonaRepository = IPersonaRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(EliminarPersonaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
               var idUsuarioPerfil = await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (request.idPersona == 0) throw new MreException(Constantes.MensajesError.EX_PERSONA_ID_REQUIRED);
                var validacion = await _IPersonaRepository.tieneUsuarioActivo(request.idPersona);
                if (validacion == 1) throw new MreException(Constantes.MensajesError.EX_PERSONA_USUARIO_ACTIVO);
                var entity = PersonaMap.MaptoEntity(request);

                entity.usuarioModificacion = idUsuarioPerfil.ToString();
                var result = await _IPersonaRepository.Eliminar(entity);


                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_PERSONA_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
