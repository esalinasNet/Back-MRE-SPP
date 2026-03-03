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
    public class AgregarPlanillaCommand : IRequestHandler<AgregarPlanillaViewModel, CommandResponseViewModel>
    {
        private readonly IPlanillaRepository _IPlanillaRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarPlanillaCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IPlanillaRepository IPlanillaRepository)
        {
            _IPlanillaRepository = IPlanillaRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarPlanillaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionRecurso == 0) throw new MreException("Debe seleccionar un recurso");
                if (request.idProgramacionTareas == 0) throw new MreException("Debe seleccionar una tarea");
                if (request.idAnio == 0) throw new MreException("Debe seleccionar un año");
                if (request.idTrabajador == 0) throw new MreException("Debe seleccionar un trabajador");
                if (request.idClasificador == 0) throw new MreException("Debe seleccionar un clasificador");
                if (request.idEstado == 0) throw new MreException("Debe seleccionar un estado");

                var entity = PlanillaMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _IPlanillaRepository.Guardar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "Planilla registrada correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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