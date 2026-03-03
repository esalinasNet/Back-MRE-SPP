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

namespace Mre.OTI.Presupuesto.Application.Features.ProyectoDetalle.Command
{
    public class AgregarProyectoDetalleCommand : IRequestHandler<AgregarProyectoDetalleViewModel, CommandResponseViewModel>
    {
        private readonly IProyectoDetalleRepository _IProyectoDetalleRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public AgregarProyectoDetalleCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IProyectoDetalleRepository IProyectoDetalleRepository)
        {
            _IProyectoDetalleRepository = IProyectoDetalleRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(AgregarProyectoDetalleViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionProyecto == 0) throw new MreException("Debe especificar el Proyecto");
                if (string.IsNullOrWhiteSpace(request.codigoItem)) throw new MreException("Debe ingresar el código del ítem");
                if (string.IsNullOrWhiteSpace(request.descripcion)) throw new MreException("Debe ingresar la descripción");
                if (request.idUnidadMedida == 0) throw new MreException("Debe seleccionar una unidad de medida");
                if (request.idClasificador == 0) throw new MreException("Debe seleccionar un clasificador");

                var entity = ProyectoDetalleMap.MaptoEntity(request);
                var idUsuarioCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioCreacion;

                var result = await _IProyectoDetalleRepository.Guardar(entity);

                string mensaje = request.idProgramacionProyectoDetalle > 0
                    ? "Detalle de Proyecto actualizado correctamente"
                    : "Detalle de Proyecto registrado correctamente";

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