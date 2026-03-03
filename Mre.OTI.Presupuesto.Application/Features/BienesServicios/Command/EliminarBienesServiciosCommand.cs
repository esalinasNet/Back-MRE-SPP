using MediatR;
using Mre.OTI.Passport.Util.Encriptador;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.BienesServicios.Command
{
    public class EliminarBienesServiciosCommand : IRequestHandler<EliminarBienesServiciosViewModel, CommandResponseViewModel>
    {
        readonly private IBienesServiciosRepository _IBienesServiciosRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarBienesServiciosCommand(IBienesServiciosRepository IBienesServiciosRepository, IUsuarioRolRepository IIUsuarioRolRepository)
        {
            _IBienesServiciosRepository = IBienesServiciosRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;

        }
        public async Task<CommandResponseViewModel> Handle(EliminarBienesServiciosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol>
            {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            if (request.idBienesServicios == 0) throw new MreException(Constantes.MensajesError.EX_BIENESSERVICIOS_ELIMINAR_ID_REQUIRED);

            var entity = BienesServiciosMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;

            var result = await _IBienesServiciosRepository.Eliminar(entity);

            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_BIENESSERVICIOS_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };
        }
    }
}
