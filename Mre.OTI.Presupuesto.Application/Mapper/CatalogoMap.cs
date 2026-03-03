using Mre.OTI.Presupuesto.Application.DTO.Catalogo;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Command;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Catalogo;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{   
    public class CatalogoMap
    {
        public static ObtenerListadoCatalogoResponseViewModel MaptoViewModel(dynamic catalogoItem)
        {
            return new ObtenerListadoCatalogoResponseViewModel()
            {
                idCatalogo = catalogoItem.ID_CATALOGO,
                nombreCatalogo = catalogoItem.DESCRIPCION_CATALOGO,
                codigoCatalogo = catalogoItem.CODIGO_CATALOGO,
                mantenible = catalogoItem.MANTENIBLE_POR_USUARIO
            };

        }

        //public static CatalogoItemDTO MaptoDTO(dynamic catalogoItem)
        //{
        //    return new CatalogoItemDTO()
        //    {
        //        abreviaturaCatalogoItem = catalogoItem.ABREVIATURA_CATALOGO_ITEM,
        //        codigoCatalogoItem = catalogoItem.CODIGO_CATALOGO_ITEM,
        //        descripcionCatalogoItem = catalogoItem.DESCRIPCION_CATALOGO_ITEM,
        //        idCatalogoItem = catalogoItem.ID_CATALOGO_ITEM
        //    };
        //}

        public static Catalogo MaptoEntity(AgregarCatalogoViewModel request)
        {
            return new Catalogo()
            {
                ID_CATALOGO = request.idCatalogo,
                DESCRIPCION_CATALOGO = request.descripcionCatalogo,
                CODIGO_CATALOGO = request.codigoCatalogo,
                MANTENIBLE_POR_USUARIO = request.manteniblePorUsuario,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            }; ;
        }
        public static Catalogo MaptoEntity(ActualizarCatalogoViewModel request)
        {
            return new Catalogo()
            {
                ID_CATALOGO = request.idCatalogo,
                DESCRIPCION_CATALOGO = request.descripcionCatalogo,
                CODIGO_CATALOGO = request.codigoCatalogo,
                MANTENIBLE_POR_USUARIO = request.manteniblePorUsuario,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }
        public static Catalogo MaptoEntity(EliminarCatalogoViewModel request)
        {
            return new Catalogo()
            {
                ID_CATALOGO = request.idCatalogo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            }; ;
        }
        public static ObtenerCatalogoPaginadoRequestDTO MaptoDTO(ObtenerCatalogoPaginadoViewModel item)
        {
            return new ObtenerCatalogoPaginadoRequestDTO()
            {
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina
            };
        }
        public static ObtenerCatalogoRequestDTO MaptoDTO(ObtenerCatalogoViewModel item)
        {
            return new ObtenerCatalogoRequestDTO()
            {
                idCatalogo = item.idCatalogo
            };
        }


        public static ObtenerCatalogoPaginadoResponseDTO MaptoDTO(Catalogo item)
        {
            return new ObtenerCatalogoPaginadoResponseDTO()
            {
                idCatalogo = item.ID_CATALOGO,
                codigoCatalogo = item.CODIGO_CATALOGO,
                nombreCatalogo = item.DESCRIPCION_CATALOGO,
                mantenible = item.MANTENIBLE_POR_USUARIO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

    }
}
