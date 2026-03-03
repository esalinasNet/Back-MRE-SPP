using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Command
{
    public class EliminarEspecificaGastoCommand : IRequestHandler<EliminarEspecificaGastoViewModel, CommandResponseViewModel>
    {
        private readonly IEspecificaGastoRepository _IEspecificaGastoRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarEspecificaGastoCommand(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEspecificaGastoRepository IEspecificaGastoRepository)
        {
            _IEspecificaGastoRepository = IEspecificaGastoRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(EliminarEspecificaGastoViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idClasificador == 0) throw new MreException(Constantes.MensajesError.EX_ESPECIFICA_GASTO_ELIMINAR_ID_REQUIRED);

            var entity = EspecificaGastoMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IEspecificaGastoRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_FUNCION_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
