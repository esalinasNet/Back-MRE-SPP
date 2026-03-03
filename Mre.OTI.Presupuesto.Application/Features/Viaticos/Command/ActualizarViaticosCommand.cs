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

namespace Mre.OTI.Presupuesto.Application.Features.Viaticos.Command
{
    public class ActualizarViaticosCommand : IRequestHandler<ActualizarViaticosViewModel, CommandResponseViewModel>
    {
        private readonly IViaticosRepository _IViaticosRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarViaticosCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IViaticosRepository IViaticosRepository)
        {
            _IViaticosRepository = IViaticosRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarViaticosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionViaticos == 0) throw new MreException("Debe especificar el ID del Viático");
                if (request.idEstado == 0) throw new MreException("Debe seleccionar un estado");

                var entity = ViaticosMap.MaptoEntity(request);

                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _IViaticosRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "Viático actualizado correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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