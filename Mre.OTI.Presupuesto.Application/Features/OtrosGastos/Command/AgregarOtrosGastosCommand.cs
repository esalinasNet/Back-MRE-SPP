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

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Command
{
    public class AgregarOtrosGastosCommand : IRequestHandler<AgregarOtrosGastosViewModel, CommandResponseViewModel>
    {
        private readonly IOtrosGastosRepository _IOtrosGastosRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarOtrosGastosCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IOtrosGastosRepository IOtrosGastosRepository)
        {
            _IOtrosGastosRepository = IOtrosGastosRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarOtrosGastosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionRecurso == 0) throw new MreException("Debe seleccionar un recurso");
                if (request.idProgramacionTareas == 0) throw new MreException("Debe seleccionar una tarea");
                if (request.idAnio == 0) throw new MreException("Debe seleccionar un año");
                if (request.idEstado == 0) throw new MreException("Debe seleccionar un estado");

                var entity = OtrosGastosMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _IOtrosGastosRepository.Guardar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "Otros Gastos registrado correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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