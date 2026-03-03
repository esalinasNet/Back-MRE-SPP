using Mre.OTI.Presupuesto.Application.DTO;
using Mre.OTI.Presupuesto.Application.DTO.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Command;
using Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class CatalogoItemMap
    {
        public static CatalogoItemViewModel MaptoViewModel(dynamic catalogoItem)
        {
            return new CatalogoItemViewModel()
            {
                abreviaturaCatalogoItem = catalogoItem.ABREVIATURA_CATALOGO_ITEM,
                codigoCatalogoItem = catalogoItem.CODIGO_CATALOGO_ITEM,
                descripcionCatalogoItem = catalogoItem.DESCRIPCION_CATALOGO_ITEM,
                detalleCatalogoItem = catalogoItem.DETALLE_CATALOGO_ITEM,
                idCatalogoItem = catalogoItem.ID_CATALOGO_ITEM,
                codigo = catalogoItem.CODIGO_CATALOGO_ITEM,
                descripcion = catalogoItem.DESCRIPCION_CATALOGO_ITEM,
                id = catalogoItem.ID_CATALOGO_ITEM,
                CentroCostos=catalogoItem.CentroCostos
            };

        }
        public static CatalogoItem MaptoEntity(ActualizarCatalogoItemViewModel request)
        {
            return new CatalogoItem()
            {
                AbreviaturaCatalogoItem = request.AbreviaturaCatalogoItem,
                //codigoCatalogoItem = request.codigoCatalogoItem,
                descripcionCatalogoItem = request.descripcionCatalogoItem,
                idCatalogoItem = request.idCatalogoItem,
                ipModificacion = request.ipModificacion,
                 detalleCatalogoItem=request.detalleCatalogoItem,
                //idCatalogo = request.idCatalogo,
                //orden = request.orden,
                usuarioModificacion = request.usuarioModificacion
            }; ;
        }
        public static CatalogoItem MaptoEntity(EliminarCatalogoItemViewModel request)
        {
            return new CatalogoItem()
            {
                idCatalogoItem = request.idCatalogoItem,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }
        public static CatalogoItemDTO MaptoDTO(dynamic catalogoItem)
        {
            return new CatalogoItemDTO()
            {
                abreviaturaCatalogoItem = catalogoItem.ABREVIATURA_CATALOGO_ITEM,
                codigoCatalogoItem = catalogoItem.CODIGO_CATALOGO_ITEM,
                descripcionCatalogoItem = catalogoItem.DESCRIPCION_CATALOGO_ITEM,
                idCatalogoItem = catalogoItem.ID_CATALOGO_ITEM,
                detalleCatalogoItem = catalogoItem.DETALLE_CATALOGO_ITEM,
            };
        }

        public static CatalogoItem MaptoEntity(AgregarCatalogoItemViewModel request)
        {
            return new CatalogoItem()
            {
                AbreviaturaCatalogoItem = request.AbreviaturaCatalogoItem,
                // codigoCatalogoItem = request.codigoCatalogoItem,
                descripcionCatalogoItem = request.descripcionCatalogoItem,
                detalleCatalogoItem = request.detalleCatalogoItem,
                idCatalogo = request.idCatalogo,
                ipCreacion = request.ipCreacion,
                //orden = request.orden,
                usuarioCreacion = request.usuarioCreacion
            };
        }

        public static ObtenerCatalogoItemPaginadoRequestDTO MaptoDTO(ObtenerCatalogoItemPaginadoViewModel item)
        {
            return new ObtenerCatalogoItemPaginadoRequestDTO()
            {
                idCatalogo = item.idCatalogo,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina
            };
        }


        public static ObtenerCatalogoItemPaginadoResponseDTO MaptoDTO(CatalogoItem item)
        {
            return new ObtenerCatalogoItemPaginadoResponseDTO()
            {
                idCatalogo = item.idCatalogo,
                AbreviaturaCatalogoItem = item.AbreviaturaCatalogoItem,
                codigoCatalogoItem = item.codigoCatalogoItem,
                descripcionCatalogoItem = item.descripcionCatalogoItem,
                eliminado = item.eliminado,
                idCatalogoItem = item.idCatalogoItem,
                orden = item.orden,
                registro = item.registro,
                totalRegistro = item.totalRegistro,
                detalleCatalogoItem=item.detalleCatalogoItem
            };
        }

    }
}
