using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Command
{
    public class EliminarCatalogoItemCommand : IRequestHandler<EliminarCatalogoItemViewModel, CommandResponseViewModel>
    {
        readonly private ICatalogoItemRepository _ICatalogoItemRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public EliminarCatalogoItemCommand(ICatalogoItemRepository ICatalogoItemRepository, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _ICatalogoItemRepository = ICatalogoItemRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(EliminarCatalogoItemViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });


            if (request.idCatalogoItem == 0) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ELIMINAR_ID_REQUIRED);

            var entity = CatalogoItemMap.MaptoEntity(request);
            var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
            entity.usuarioModificacion = idUsuarioRolModificacion;
            var result = await _ICatalogoItemRepository.Eliminar(entity);


            return new CommandResponseViewModel
            {
                message = result > 0 ? Constantes.MensajesOK.M01_CATALOGOITEM_DELETE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                result = result
            };


        }
    }
}
