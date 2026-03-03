using Mre.OTI.Presupuesto.Application.DTO.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Command;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static iTextSharp.text.pdf.AcroFields;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProgramacionClasificadorMap
    {
        public static ObtenerProgramacionClasificadorPaginadoResponseDTO MaptoDTO(ProgramacionClasificador item)
        {
            return new ObtenerProgramacionClasificadorPaginadoResponseDTO()
            {
                idProgramacionClasificador = item.ID_PROGRAMACION_CLASIFICADOR,
                idAnio = item.ID_ANIO,

                idProgramacionActividad = item.ID_PROGRAMACION_ACTIVIDAD,
                idFuenteFinanciamiento = item.ID_FUENTE_FINANCIAMIENTO,
                idClasificador = item.ID_CLASIFICADOR,

                codigoClasificador = item.CODIGO_CLASIFICADOR,
                descripcionClasificador = item.DESCRIPCION_CLASIFICADOR,

                metaFinanciera = item.META_FINANCIERA,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerProgramacionClasificadorPaginadoRequestDTO MaptoDTO(ObtenerProgramacionClasificadorPaginadoViewModel item)
        {
            return new ObtenerProgramacionClasificadorPaginadoRequestDTO()
            {
                anio = item.anio,

                idProgramacionActividad = item.idProgramacionActividad,
                codigoClasificador = item.codigoClasificador,
                descripcionClasificador = item.descripcionClasificador,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerProgramacionClasificadorRequestDTO MaptoDTO(ObtenerProgramacionClasificadorViewModel item)
        {
            return new ObtenerProgramacionClasificadorRequestDTO()
            {
                idProgramacionClasificador = item.idProgramacionClasificador
            };
        }

        public static ProgramacionClasificador MaptoEntity(AgregarProgramacionClasificadorViewModel request)
        {
            return new ProgramacionClasificador()
            {
                ID_ANIO = request.idAnio,
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                ID_CLASIFICADOR = request.idClasificador,

                CODIGO_CLASIFICADOR = request.codigoClasificador,
                DESCRIPCION_CLASIFICADOR = request.descripcionClasificador,

                META_FINANCIERA = request.metaFinanciera,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static ProgramacionClasificador MaptoEntity(ActualizarProgramacionClasificadorViewModel request)
        {
            return new ProgramacionClasificador()
            {
                ID_PROGRAMACION_CLASIFICADOR = request.idProgramacionClasificador,
                ID_ANIO = request.idAnio,
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                ID_CLASIFICADOR = request.idClasificador,

                CODIGO_CLASIFICADOR = request.codigoClasificador,
                DESCRIPCION_CLASIFICADOR = request.descripcionClasificador,

                META_FINANCIERA = request.metaFinanciera,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ProgramacionClasificador MaptoEntity(EliminarProgramacionClasificadorViewModel request)
        {
            return new ProgramacionClasificador()
            {
                ID_PROGRAMACION_CLASIFICADOR = request.idProgramacionClasificador,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoProgramacionClasificadorRequestDTO MaptoDTOCodigoProgramacionClasificador(ObtenerCodigoProgramacionClasificadorViewModel item)
        {
            return new ObtenerCodigoProgramacionClasificadorRequestDTO()
            {
                anio = item.anio,
                codigoClasificador = item.codigoClasificador
            };
        }

        public static ObtenerListadoProgramacionClasificadorResponseViewModel MaptoViewModelProgramacionClasificador(dynamic item)
        {
            return new ObtenerListadoProgramacionClasificadorResponseViewModel()
            {
                idProgramacionClasificador = item.idProgramacionClasificador,
                idAnio = item.idAnio,
                anio = item.anio,

                idProgramacionActividad = item.idProgramacionActividad,
                codigoProgramacion = item.codigoProgramacion,

                idFuenteFinanciamiento = item.idFuenteFinanciamiento,
                codigoFuente = item.codigoFuente,
                descripcionFuente = item.descripcionFuente,

                codigoClasificador = item.codigoClasificador,
                descripcionClasificador = item.descripcionClasificador,
                
                metaFinanciera = item.metaFinanciera,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoProgramacionClasificadorRequestDTO MaptoProgramacionClasificadorDTO(ObtenerListadoProgramacionClasificadorViewModel item)
        {
            return new ObtenerListadoProgramacionClasificadorRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static ObtenerListadoProgramacionClasificadorPorActividadRequestDTO MaptoProgramacionClasificadorPorActividadDTO(ObtenerListadoProgramacionClasificadorPorActividadViewModel item)
        {
            return new ObtenerListadoProgramacionClasificadorPorActividadRequestDTO()
            {
                idAnio = item.idAnio,
                idProgramacionActividad = item.idProgramacionActividad
            };
        }

        public static ObtenerProgramacionActividadClasificadorRequestDTO MaptoActividadClasificadorDTO(ObtenerProgramacionActividadClasificadorViewModel item)
        {
            return new ObtenerProgramacionActividadClasificadorRequestDTO()
            {
                idProgramacionActividad = item.idProgramacionActividad
            };
        }
    }
}
