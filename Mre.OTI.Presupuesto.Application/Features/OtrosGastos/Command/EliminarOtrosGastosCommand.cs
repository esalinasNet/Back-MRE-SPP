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
    public class EliminarOtrosGastosCommand : IRequestHandler<EliminarOtrosGastosViewModel, CommandResponseViewModel>
    {
        private readonly IOtrosGastosRepository _IOtrosGastosRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarOtrosGastosCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IOtrosGastosRepository IOtrosGastosRepository)
        {
            _IOtrosGastosRepository = IOtrosGastosRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(EliminarOtrosGastosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionOtrosGastos == 0) throw new MreException("Debe especificar el ID de Otros Gastos");

                var entity = OtrosGastosMap.MaptoEntity(request);
                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IOtrosGastosRepository.Eliminar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "Otros Gastos eliminado correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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