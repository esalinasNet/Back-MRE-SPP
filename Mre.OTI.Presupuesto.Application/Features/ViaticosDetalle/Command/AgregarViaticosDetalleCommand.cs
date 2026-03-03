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

namespace Mre.OTI.Presupuesto.Application.Features.ViaticosDetalle.Command
{
    public class AgregarViaticosDetalleCommand : IRequestHandler<AgregarViaticosDetalleViewModel, CommandResponseViewModel>
    {
        private readonly IViaticosDetalleRepository _IViaticosDetalleRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarViaticosDetalleCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IViaticosDetalleRepository IViaticosDetalleRepository)
        {
            _IViaticosDetalleRepository = IViaticosDetalleRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarViaticosDetalleViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionViaticos == 0) throw new MreException("Debe especificar el Viático");
                if (request.idClasificador == 0) throw new MreException("Debe seleccionar un clasificador");
                if (string.IsNullOrWhiteSpace(request.nombreClasificador)) throw new MreException("Debe ingresar el nombre del clasificador");
                if (string.IsNullOrWhiteSpace(request.denominacionRecurso)) throw new MreException("Debe ingresar la denominación del recurso");
                if (request.monto <= 0) throw new MreException("El monto debe ser mayor a cero");
                if (request.cantidadPersonas <= 0) throw new MreException("La cantidad de personas debe ser mayor a cero");
                if (request.dias <= 0) throw new MreException("Los días deben ser mayor a cero");
                if (request.mes < 1 || request.mes > 12) throw new MreException("El mes debe estar entre 1 y 12");

                var entity = ViaticosDetalleMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _IViaticosDetalleRepository.Guardar(entity);

                string mensaje = request.idProgramacionViaticosDetalle > 0
                    ? "Detalle de Viáticos actualizado correctamente"
                    : "Detalle de Viáticos registrado correctamente";

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