using Mre.OTI.Presupuesto.Application.DTO.UnidadMedida;
using Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Command;
using Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries;
using Mre.OTI.Presupuesto.Application.Responses.UnidadMedida;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class UnidadMedidaMap
    {
        public static UnidadMedida MaptoEntity(AgregarUnidadMedidaViewModel request)
        {
            return new UnidadMedida()
            {
                ID_ANIO = request.idAnio,

                UNIDADMEDIDA = request.unidadMedida,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static UnidadMedida MaptoEntity(ActualizarUnidadMedidaViewModel request)
        {
            return new UnidadMedida()
            {
                ID_UNIDADMEDIDA = request.idUnidadMedida,
                ID_ANIO = request.idAnio,

                UNIDADMEDIDA = request.unidadMedida,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static UnidadMedida MaptoEntity(EliminarUnidadMedidaViewModel request)
        {
            return new UnidadMedida()
            {
                ID_UNIDADMEDIDA = request.idUnidadMedida,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerListadoUnidadMedidaResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoUnidadMedidaResponseViewModel()
            {
                idUnidadMedida = item.idUnidadMedida,
                idAnio = item.idAnio,
                anio = item.anio,

                unidadMedida = item.unidadMedida,
                descripcion = item.descripcion,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoUnidadMedidaRequestDTO MaptoUnidadMedidaDTO(ObtenerListadoUnidadMedidaViewModel item)
        {
            return new ObtenerListadoUnidadMedidaRequestDTO()
            {
                idAnio = item.idAnio
            };
        }


        public static ObtenerUnidadMedidaPaginadoResponseDTO MaptoDTO(UnidadMedida item)
        {
            return new ObtenerUnidadMedidaPaginadoResponseDTO()
            {
                idUnidadMedida = item.ID_UNIDADMEDIDA,
                idAnio = item.ID_ANIO,

                unidadMedida = item.UNIDADMEDIDA,
                descripcion = item.DESCRIPCION,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerUnidadMedidaPaginadoRequestDTO MaptoDTO(ObtenerUnidadMedidaPaginadoViewModel item)
        {
            return new ObtenerUnidadMedidaPaginadoRequestDTO()
            {
                anio = item.anio,

                unidadMedida = item.unidadMedida,
                descripcion = item.descripcion,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerUnidadMedidaRequestDTO MaptoDTO(ObtenerUnidadMedidaViewModel item)
        {
            return new ObtenerUnidadMedidaRequestDTO()
            {
                idUnidadMedida = item.idUnidadMedida
            };
        }

        public static ObtenerCodigoUnidadMedidaRequestDTO MaptoDTOCodigoGrupo(ObtenerCodigoUnidadMedidaViewModel item)
        {
            return new ObtenerCodigoUnidadMedidaRequestDTO()
            {
                anio = item.anio,
                unidadMedida = item.unidadMedida,
            };
        }
    }
}
