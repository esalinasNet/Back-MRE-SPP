using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Actividad.Command;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Actividad.Command
{
    public class EliminarActividadCommand : IRequestHandler<EliminarActividadViewModel, CommandResponseViewModel>
    {
        readonly private IActividadRepository _IActividadRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarActividadCommand(IActividadRepository IActividadRepository, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _IActividadRepository = IActividadRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;

        }
        public async Task<CommandResponseViewModel> Handle(EliminarActividadViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idActividad == 0) throw new MreException(Constantes.MensajesError.EX_ACTIVIDAD_ELIMINAR_ID_REQUIRED);

            var entity = ActividadMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IActividadRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_ACTIVIDAD_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
