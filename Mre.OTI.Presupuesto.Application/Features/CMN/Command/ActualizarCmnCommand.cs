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

namespace Mre.OTI.Presupuesto.Application.Features.Cmn.Command
{
    public class ActualizarCmnCommand : IRequestHandler<ActualizarCmnViewModel, CommandResponseViewModel>
    {
        private readonly ICmnRepository _ICmnRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarCmnCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICmnRepository ICmnRepository)
        {
            _ICmnRepository = ICmnRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<CommandResponseViewModel> Handle(ActualizarCmnViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                if (request.idProgramacionCmn == 0) throw new MreException("Debe especificar el ID del CMN");
                if (request.idEstado == 0) throw new MreException("Debe seleccionar un estado");

                var entity = CmnMap.MaptoEntity(request);
                var idUsuarioModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioModificacion;

                var result = await _ICmnRepository.Actualizar(entity);

                return new CommandResponseViewModel
                {
                    message = result > 0 ? "CMN actualizado correctamente" : Constantes.MensajesError.EX_ERROR_GENERICO,
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