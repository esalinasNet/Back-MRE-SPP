using Mre.OTI.Presupuesto.Application.DTO.Finalidad;
using Mre.OTI.Presupuesto.Application.Features.Finalidad.Command;
using Mre.OTI.Presupuesto.Application.Features.Finalidad.Queries;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class FinalidadMap
    {
        public static Finalidad MaptoEntity(AgregarFinalidadViewModel request)
        {
            return new Finalidad()
            {
                ID_ANIO = request.idAnio,

                FINALIDAD = request.finalidad,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static Finalidad MaptoEntity(ActualizarFinalidadViewModel request)
        {
            return new Finalidad()
            {
                ID_FINALIDAD = request.idFinalidad,
                ID_ANIO = request.idAnio,

                FINALIDAD = request.finalidad,
                DESCRIPCION = request.descripcion,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,

                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static Finalidad MaptoEntity(EliminarFinalidadViewModel request)
        {
            return new Finalidad()
            {
                ID_FINALIDAD = request.idFinalidad,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerListadoFinalidadResponseViewModel MaptoViewModel(dynamic item)
        {
            return new ObtenerListadoFinalidadResponseViewModel()
            {
                idFinalidad = item.idFinalidad,
                idAnio = item.idAnio,
                anio = item.anio,

                finalidad = item.finalidad,
                descripcion = item.descripcion,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoFinalidadRequestDTO MaptoFinalidadDTO(ObtenerListadoFinalidadViewModel item)
        {
            return new ObtenerListadoFinalidadRequestDTO()
            {
                idAnio = item.idAnio
            };
        }


        public static ObtenerFinalidadPaginadoResponseDTO MaptoDTO(Finalidad item)
        {
            return new ObtenerFinalidadPaginadoResponseDTO()
            {
                idFinalidad = item.ID_FINALIDAD,
                idAnio = item.ID_ANIO,

                finalidad = item.FINALIDAD,
                descripcion = item.DESCRIPCION,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerFinalidadPaginadoRequestDTO MaptoDTO(ObtenerFinalidadPaginadoViewModel item)
        {
            return new ObtenerFinalidadPaginadoRequestDTO()
            {
                anio = item.anio,

                finalidad = item.finalidad,
                descripcion = item.descripcion,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerFinalidadRequestDTO MaptoDTO(ObtenerFinalidadViewModel item)
        {
            return new ObtenerFinalidadRequestDTO()
            {
                idFinalidad = item.idFinalidad
            };
        }

        public static ObtenerCodigoFinalidadRequestDTO MaptoDTOCodigoFinalidad(ObtenerCodigoFinalidadViewModel item)
        {
            return new ObtenerCodigoFinalidadRequestDTO()
            {
                anio = item.anio,
                finalidad = item.finalidad,
            };
        }
    }
}
