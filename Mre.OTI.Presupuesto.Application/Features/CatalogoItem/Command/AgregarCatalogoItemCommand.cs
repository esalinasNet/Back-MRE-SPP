using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.CatalogoItem;
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

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Command
{
    public class AgregarCatalogoItemCommand : IRequestHandler<AgregarCatalogoItemViewModel, CommandResponseViewModel>
    {
        readonly private ICatalogoItemRepository _ICatalogoItemRepository;
        readonly private IUnitOfWork _IUnitOfWork;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public AgregarCatalogoItemCommand(ICatalogoItemRepository ICatalogoItemRepository, IUnitOfWork IUnitOfWork, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _ICatalogoItemRepository = ICatalogoItemRepository;
            _IUnitOfWork = IUnitOfWork;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<CommandResponseViewModel> Handle(AgregarCatalogoItemViewModel request, CancellationToken cancellationToken)
        {
            _IUnitOfWork.BeginTransaction();
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioCreacion, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });


                if (string.IsNullOrEmpty(request.descripcionCatalogoItem)) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ITEM_DESCRIPCION_REQUIRED);
                var entity = CatalogoItemMap.MaptoEntity(request);
                var idUsuarioRolCreacion = EncryptionPassportHandler.Decrypt(request.usuarioCreacion, Constantes.SISTEMA.KEY_ENCRYPT);
                entity.usuarioCreacion = idUsuarioRolCreacion;
                entity.fechaCreacion = DateTime.Now;
                entity.activo = true;
                if (entity.idCatalogo == 0) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ITEM_CATALOGO_REQUIRED);
                var valNombreCatalogoItem = await _ICatalogoItemRepository.ObtenerCatalogoItemVal(new ObtenerCatalogoItemValRequestDTO()
                {
                     idCatalogo =entity.idCatalogo,
                    nombreCatalogoItem = entity.descripcionCatalogoItem,
                });
                if (valNombreCatalogoItem != null) throw new MreException(Constantes.MensajesError.EX_CATALOGO_ITEM_NOMBRE_DP);

                /* var valCodigoCatalogoItem = await _ICatalogoItemRepository.ObtenerCatalogoItemVal(new ObtenerCatalogoItemValRequestDTO()
                 {
                     codigoCatalogoItem = entity.codigoCatalogoItem,
                 });
                 if (valCodigoCatalogoItem != null) throw new UarmException(Constantes.MensajesError.EX_CATALOGO_ITEM_CODIGO_DP);
                */

                var ordenActual = await _ICatalogoItemRepository.ObtenerNumeroOrderCatalogo(entity.idCatalogo);
                entity.orden = ordenActual + 1;
                entity.codigoCatalogoItem = entity.orden;
                var result = await _ICatalogoItemRepository.Guardar(entity);

                _IUnitOfWork.Commit();
                return new CommandResponseViewModel
                {
                    message = result > 0 ? Constantes.MensajesOK.M01_CATALOGOITEM_INSERT_OK : Constantes.MensajesError.EX_ERROR_GENERICO,
                    result = result
                };
            }
            catch (Exception ex)
            {
                _IUnitOfWork.Rollback();
                throw ex;
            }


        }
    }
}
