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

namespace Mre.OTI.Presupuesto.Application.Features.CajaChicaDetalle.Command
{
    public class AgregarCajaChicaDetalleCommand : IRequestHandler<AgregarCajaChicaDetalleViewModel, CommandResponseViewModel>
    {
        private readonly ICajaChicaDetalleRepository _ICajaChicaDetalleRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarCajaChicaDetalleCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICajaChicaDetalleRepository ICajaChicaDetalleRepository)
        {
            _ICajaChicaDetalleRepository = ICajaChicaDetalleRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarCajaChicaDetalleViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionCajaChica == 0) throw new MreException("Debe especificar la Caja Chica");
                if (string.IsNullOrWhiteSpace(request.codigoItem)) throw new MreException("Debe ingresar el código del ítem");
                if (string.IsNullOrWhiteSpace(request.descripcion)) throw new MreException("Debe ingresar la descripción");
                if (request.idUnidadMedida == 0) throw new MreException("Debe seleccionar una unidad de medida");
                if (request.idClasificador == 0) throw new MreException("Debe seleccionar un clasificador");

                var entity = CajaChicaDetalleMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _ICajaChicaDetalleRepository.Guardar(entity);

                string mensaje = request.idProgramacionCajaChicaDetalle > 0
                    ? "Detalle de Caja Chica actualizado correctamente"
                    : "Detalle de Caja Chica registrado correctamente";

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