using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Command;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProgramacionTareasMap
    {
        public static ObtenerProgramacionTareasPaginadoResponseDTO MaptoDTO(ProgramacionTareas item)
        {
            return new ObtenerProgramacionTareasPaginadoResponseDTO()
            {
                idProgramacionTareas = item.ID_PROGRAMACION_TAREAS,
                idAnio = item.ID_ANIO,

                idProgramacionActividad = item.ID_PROGRAMACION_ACTIVIDAD,

                //idProgramacionClasificador =  item.ID_PROGRAMACION_CLASIFICADOR,

                codigoTareas = item.CODIGO_TAREAS,
                descripcionTareas = item.DESCRIPCION_TAREAS,

                ubigeo = item.UBIGEO,
                idUnidadMedida = item.ID_UNIDAD_MEDIDA,

                representativa = item.REPRESENTATIVA,

                idFuenteFinanciamiento = item.ID_FUENTE_FINANCIAMIENTO,
                metaFisica = item.META_FISICA,
                metaFinanciera = item.META_FINANCIERA,

                idEstado = item.ID_ESTADO,
                registro = item.registro,
                totalRegistro = item.totalRegistro
            };
        }

        public static ObtenerProgramacionTareasPaginadoRequestDTO MaptoDTO(ObtenerProgramacionTareasPaginadoViewModel item)
        {
            return new ObtenerProgramacionTareasPaginadoRequestDTO()
            {
                anio = item.anio,

                idProgramacionActividad = item.idProgramacionActividad,
                //idProgramacionClasificador = item.idProgramacionClasificador,

                codigoTareas = item.codigoTareas,
                //descripcionTareas = item.descripcionTareas,

                //descripcionUnidadMedida = item.descripcionUnidadMedida,

                estadoDescripcion = item.estadoDescripcion,

                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerProgramacionTareasRequestDTO MaptoDTO(ObtenerProgramacionTareasViewModel item)
        {
            return new ObtenerProgramacionTareasRequestDTO()
            {
                idProgramacionTareas = item.idProgramacionTareas
            };
        }

        public static ProgramacionTareas MaptoEntity(AgregarProgramacionTareasViewModel request)
        {
            return new ProgramacionTareas()
            {
                ID_ANIO = request.idAnio,
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                //ID_PROGRAMACION_CLASIFICADOR = request.idProgramacionClasificador,
                CODIGO_TAREAS = request.codigoTareas,
                DESCRIPCION_TAREAS = request.descripcionTareas,

                UBIGEO = request.ubigeo,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                META_FISICA = request.metaFisica,
                META_FINANCIERA = request.metaFinanciera,

                ID_ESTADO = request.idEstado,

                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static ProgramacionTareas MaptoEntity(ActualizarProgramacionTareasViewModel request)
        {
            return new ProgramacionTareas()
            {
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,
                ID_ANIO = request.idAnio,
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                //ID_PROGRAMACION_CLASIFICADOR = request.idProgramacionClasificador,
                CODIGO_TAREAS = request.codigoTareas,
                DESCRIPCION_TAREAS = request.descripcionTareas,

                UBIGEO = request.ubigeo,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                META_FISICA = request.metaFisica,
                META_FINANCIERA = request.metaFinanciera,

                ID_ESTADO = request.idEstado,
                ACTIVO = request.activo,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ProgramacionTareas MaptoEntity(EliminarProgramacionTareasViewModel request)
        {
            return new ProgramacionTareas()
            {
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionTareas,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerCodigoProgramacionTareasRequestDTO MaptoDTOCodigoProgramacionTareas(ObtenerCodigoProgramacionTareasViewModel item)
        {
            return new ObtenerCodigoProgramacionTareasRequestDTO()
            {
                anio = item.anio,
                codigoTareas = item.codigoTareas
            };
        }

        public static ObtenerUnidadMedidaProgramacionTareasRequestDTO MaptoDTOUnidadMedidaProgramacionTareas(ObtenerUnidadMedidaProgramacionTareasViewModel item)
        {
            return new ObtenerUnidadMedidaProgramacionTareasRequestDTO()
            {
                idProgramacionTareas = item.idProgramacionTareas,
                idUnidadMedida = item.idUnidadMedida
            };
        }

        public static ObtenerListadoProgramacionTareasResponseViewModel MaptoViewModelProgramacionTareas(dynamic item)
        {
            return new ObtenerListadoProgramacionTareasResponseViewModel()
            {
                idProgramacionTareas = item.idProgramacionTareas,
                idAnio = item.idAnio,
                anio = item.anio,

                idProgramacionActividad = item.idProgramacionActividad,
                codigoProgramacion = item.codigoProgramacion,

                //idProgramacionClasificador = item.idProgramacionClasificador,
                //idClasificador = item.idClasificador,

                codigoTareas = item.codigoTareas,
                descripcionTareas = item.descripcionTareas,
                ubigeo = item.ubigeo,
                idUnidadMedida = item.idUnidadMedida,
                descripcionUnidadMedida = item.descripcionUnidadMedida,
                representativa = item.representativa,
                idFuenteFinanciamiento = item.idFuenteFinanciamiento,
                codigoFuente = item.codigoFuente,
                descripcionFuente = item.descripcionFuente,
                metaFisica = item.metaFisica,
                metaFinanciera = item.metaFinanciera,

                idEstado = item.idEstado,
                estado = item.estado,
                estadoDescripcion = item.estadoDescripcion,
                activo = item.activo
            };
        }

        public static ObtenerListadoProgramacionTareasRequestDTO MaptoProgramacionTareasDTO(ObtenerListadoProgramacionTareasViewModel item)
        {
            return new ObtenerListadoProgramacionTareasRequestDTO()
            {
                idAnio = item.idAnio
            };
        }

        public static ObtenerListadoProgramacionTareasPorActividadRequestDTO MaptoProgramacionTareasPorActividadDTO(ObtenerListadoProgramacionTareasPorActividadViewModel item)
        {
            return new ObtenerListadoProgramacionTareasPorActividadRequestDTO()
            {
                idAnio = item.idAnio,
                idProgramacionActividad = item.idProgramacionActividad
                //idProgramacionClasificador = item.idProgramacionClasificador
            };
        }

        public static ObtenerProgramacionActividadTareasRequestDTO MaptoActividadTareasDTO(ObtenerProgramacionActividadTareasViewModel item)
        {
            return new ObtenerProgramacionActividadTareasRequestDTO()
            {
                idProgramacionActividad = item.idProgramacionActividad
                //idProgramacionClasificador = item.idProgramacionClasificador
            };
        }
    }
}
