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

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastosDetalle.Command
{
    public class AgregarOtrosGastosDetalleCommand : IRequestHandler<AgregarOtrosGastosDetalleViewModel, CommandResponseViewModel>
    {
        private readonly IOtrosGastosDetalleRepository _IOtrosGastosDetalleRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarOtrosGastosDetalleCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IOtrosGastosDetalleRepository IOtrosGastosDetalleRepository)
        {
            _IOtrosGastosDetalleRepository = IOtrosGastosDetalleRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarOtrosGastosDetalleViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionOtrosGastos == 0) throw new MreException("Debe especificar el Otro Gasto");
                if (request.idClasificador == 0) throw new MreException("Debe seleccionar un clasificador");
                if (string.IsNullOrWhiteSpace(request.nombreClasificador)) throw new MreException("Debe ingresar el nombre del clasificador");
                if (string.IsNullOrWhiteSpace(request.denominacionRecurso)) throw new MreException("Debe ingresar la denominación del recurso");
                if (request.monto <= 0) throw new MreException("El monto debe ser mayor a cero");  // AGREGADO
                if (request.valor <= 0) throw new MreException("El valor debe ser mayor a cero");
                if (request.mes < 1 || request.mes > 12) throw new MreException("El mes debe estar entre 1 y 12");

                var entity = OtrosGastosDetalleMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _IOtrosGastosDetalleRepository.Guardar(entity);

                string mensaje = request.idProgramacionOtrosGastosDetalle > 0
                    ? "Detalle de Otros Gastos actualizado correctamente"
                    : "Detalle de Otros Gastos registrado correctamente";

                return new CommandResponseViewModel
                {
                    message = result > 0 ? mensaje : Constantes.MensajesError.EX_ERROR_GENERICO,
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