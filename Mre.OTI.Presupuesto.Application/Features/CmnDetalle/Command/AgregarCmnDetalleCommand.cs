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

namespace Mre.OTI.Presupuesto.Application.Features.CmnDetalle.Command
{
    public class AgregarCmnDetalleCommand : IRequestHandler<AgregarCmnDetalleViewModel, CommandResponseViewModel>
    {
        private readonly ICmnDetalleRepository _ICmnDetalleRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarCmnDetalleCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICmnDetalleRepository ICmnDetalleRepository)
        {
            _ICmnDetalleRepository = ICmnDetalleRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarCmnDetalleViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
            VariablesGlobales.TablaRol.ANALISTA_OGTH
        });

                if (request.idProgramacionCmn == 0) throw new MreException("Debe especificar el CMN");
                if (string.IsNullOrWhiteSpace(request.codigoItem)) throw new MreException("Debe ingresar el código del ítem");
                if (string.IsNullOrWhiteSpace(request.descripcion)) throw new MreException("Debe ingresar la descripción");
                // REMOVIDO: if (request.cantidad <= 0) - Ahora permite 0
                if (request.idUnidadMedida == 0) throw new MreException("Debe seleccionar una unidad de medida");
                // REMOVIDO: if (request.precioUnitario <= 0) - Ahora permite 0
                if (request.idClasificador == 0) throw new MreException("Debe seleccionar un clasificador");

                var entity = CmnDetalleMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _ICmnDetalleRepository.Guardar(entity);

                string mensaje = request.idProgramacionCmnDetalle > 0
                    ? "Detalle de CMN actualizado correctamente"
                    : "Detalle de CMN registrado correctamente";

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