using Mre.OTI.Presupuesto.Application.DTO.ProductoProyecto;
using Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Command;
using Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Queries;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProductoMap
    {
        public static Producto MaptoEntity(AgregarProductoViewModel request)
        {
            return new Producto()
            {
                ID_ANIO = request.idAnio,

                PRODUCTO = request.producto,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static Producto MaptoEntity(ActualizarProductoViewModel request)
        {
            return new Producto()
            {
                ID_PRODUCTO = request.idProducto,
                ID_ANIO = request.idAnio,

                PRODUCTO = request.producto,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static Producto MaptoEntity(EliminarProductoViewModel request)
        {
            return new Producto()
            {
                ID_PRODUCTO = request.idProducto,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerListadoProductoResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoProductoResponseViewModel()
            {
                idProducto = item.idProducto,
                idAnio = item.idAnio,
                anio = item.anio,

                producto = item.producto,
                descripcion = item.descripcion,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };

        }

        public static ObtenerListadoProductoRequestDTO MaptoProductoDTO(ObtenerListadoProductoViewModel item)
        {
            return new ObtenerListadoProductoRequestDTO()
            {
                idAnio = item.idAnio
            };
        }


        public static ObtenerProductoPaginadoResponseDTO MaptoDTO(Producto item)
        {
            return new ObtenerProductoPaginadoResponseDTO()
            {
                idProducto = item.ID_PRODUCTO,
                idAnio = item.ID_ANIO,

                producto = item.PRODUCTO,
                descripcion = item.DESCRIPCION,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerProductoPaginadoRequestDTO MaptoDTO(ObtenerProductoPaginadoViewModel item)
        {
            return new ObtenerProductoPaginadoRequestDTO()
            {
                anio = item.anio,

                producto = item.prodcuto,
                descripcion = item.descripcion,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerProductoRequestDTO MaptoDTO(ObtenerProductoViewModel item)
        {
            return new ObtenerProductoRequestDTO()
            {
                idProducto = item.idProducto
            };
        }

        public static ObtenerCodigoProductoRequestDTO MaptoDTOCodigoProducto(ObtenerCodigoProductoViewModel item)
        {
            return new ObtenerCodigoProductoRequestDTO()
            {
                anio = item.anio,
                producto = item.producto,
            };
        }
    }
}
