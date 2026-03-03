using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mre.OTI.Passport.Util.Encriptador;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Command
{
    public class ActualizarCatalogoItemCommand : IRequestHandler<ActualizarCatalogoItemViewModel, CommandResponseViewModel>
    {
        readonly private ICatalogoItemRepository _ICatalogoItemRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ActualizarCatalogoItemCommand(ICatalogoItemRepository ICatalogoItemRepository, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _ICatalogoItemRepository = ICatalogoItemRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(ActualizarCatalogoItemViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioModificacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });


                if (request.idCatalogo == 0) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ACTUALIZAR_ID_REQUIRED);
                if (request.idCatalogoItem == 0) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ITEM_ACTUALIZAR_ID_REQUIRED);
                if (string.IsNullOrEmpty(request.descripcionCatalogoItem)) throw new MreException(Constantes.MensajesError.EX_CATALOGO_NOMBRE_REQUIRED);

                var valNombreCatalogoItem = await _ICatalogoItemRepository.ObtenerCatalogoItemVal(new ObtenerCatalogoItemValRequestDTO()
                {
                    idCatalogo=request.idCatalogo,
                    nombreCatalogoItem = request.descripcionCatalogoItem,
                });
                if (valNombreCatalogoItem != null && valNombreCatalogoItem.idCatalogoItem != request.idCatalogoItem) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ITEM_NOMBRE_DP);

                /* var valCodigoCatalogoItem = await _ICatalogoItemRepository.ObtenerCatalogoItemVal(new ObtenerCatalogoItemValRequestDTO()
                 {
                     codigoCatalogoItem = request.codigoCatalogoItem,
                 });
                 if (valCodigoCatalogoItem != null && valCodigoCatalogoItem.idCatalogoItem != request.idCatalogoItem) throw new UarmException(Constantes.MensajesError.EX_CATALOGO_ITEM_CODIGO_DP);
                */
                var entity = CatalogoItemMap.MaptoEntity(request);
                var idUsuarioRolModificacion = EncryptionPassportHandler.Decrypt(request.usuarioModificacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioModificacion = idUsuarioRolModificacion;

                var result = await _ICatalogoItemRepository.Actualizar(entity);
                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_CATALOGOITEM_UPDATE_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
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
