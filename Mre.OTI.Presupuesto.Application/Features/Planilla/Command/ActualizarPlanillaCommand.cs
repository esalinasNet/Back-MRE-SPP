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

namespace Mre.OTI.Presupuesto.Application.Features.Planilla.Command
{
    public class ActualizarPlanillaCommand : IRequestHandler<ActualizarPlanillaViewModel, CommandResponseViewModel>
    {
        private readonly IPlanillaRepository _IPlanillaRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarPlanillaCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IPlanillaRepository IPlanillaRepository)
        {
            _IPlanillaRepository = IPlanillaRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarPlanillaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionPlanilla == 0) throw new MreException("Debe especificar el ID de Planilla");
                if (request.idEstado == 0) throw new MreException("Debe seleccionar un estado");

                var entity = PlanillaMap.MaptoEntity(request);
                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IPlanillaRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "Planilla actualizada correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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