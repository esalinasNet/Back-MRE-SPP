using Mre.OTI.Presupuesto.Application.DTO.Proyecto;
using Mre.OTI.Presupuesto.Application.Features.Proyecto.Queries;
using Mre.OTI.Presupuesto.Application.Features.Proyecto.Command;
using Mre.OTI.Presupuesto.Application.Responses.Proyecto;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ProyectoMap
    {
        // Mapeo de ViewModel a RequestDTO (Listado)
        public static ObtenerListadoProyectoRequestDTO MaptoProyectoDTO(ObtenerListadoProyectoViewModel item)
        {
            return new ObtenerListadoProyectoRequestDTO()
            {
                idProgramacionTareas = item.idProgramacionTareas,
                idAnio = item.idAnio,
                idActividadOperativa = item.idActividadOperativa
            };
        }

        // Mapeo para Paginado
        public static ObtenerProyectoPaginadoRequestDTO MaptoPaginadoDTO(ObtenerProyectoPaginadoViewModel item)
        {
            return new ObtenerProyectoPaginadoRequestDTO()
            {
                idProgramacionTareas = item.idProgramacionTareas,
                anio = item.anio,
                idActividadOperativa = item.idActividadOperativa,
                tipoUbigeo = item.tipoUbigeo,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        // Mapeo de Entity/Dynamic a ResponseViewModel (Listado)
        public static ObtenerListadoProyectoResponseViewModel MaptoViewModel(dynamic proyecto)
        {
            return new ObtenerListadoProyectoResponseViewModel()
            {
                idProgramacionProyecto = proyecto.idProgramacionProyecto,
                idProgramacionTareas = proyecto.idProgramacionTareas,
                idAnio = proyecto.idAnio,
                idActividadOperativa = proyecto.idActividadOperativa,
                idTarea = proyecto.idTarea,
                idUnidadMedida = proyecto.idUnidadMedida,
                representativa = proyecto.representativa,
                idFuenteFinanciamiento = proyecto.idFuenteFinanciamiento,
                idUbigeo = proyecto.idUbigeo,
                tipoUbigeo = proyecto.tipoUbigeo,

                // Montos mensuales
                montoEnero = proyecto.montoEnero,
                montoFebrero = proyecto.montoFebrero,
                montoMarzo = proyecto.montoMarzo,
                montoAbril = proyecto.montoAbril,
                montoMayo = proyecto.montoMayo,
                montoJunio = proyecto.montoJunio,
                montoJulio = proyecto.montoJulio,
                montoAgosto = proyecto.montoAgosto,
                montoSetiembre = proyecto.montoSetiembre,
                montoOctubre = proyecto.montoOctubre,
                montoNoviembre = proyecto.montoNoviembre,
                montoDiciembre = proyecto.montoDiciembre,
                montoTotal = proyecto.montoTotal,

                denominacionRecurso = proyecto.denominacionRecurso,

                // Datos relacionados
                anio = proyecto.anio,
                codigoTareas = proyecto.codigoTareas,
                descripcionTareas = proyecto.descripcionTareas,
                codigoProgramacion = proyecto.codigoProgramacion,
                denominacionActividad = proyecto.denominacionActividad,
                descripcionUnidadMedida = proyecto.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = proyecto.descripcionFuenteFinanciamiento,
                descripcionUbigeo = proyecto.descripcionUbigeo,

                idEstado = proyecto.idEstado,
                estado = proyecto.estado,
                estadoDescripcion = proyecto.estadoDescripcion,
                activo = proyecto.activo,
                usuarioCreacion = proyecto.usuarioCreacion,
                fechaCreacion = proyecto.fechaCreacion,
                usuarioModificacion = proyecto.usuarioModificacion,
                fechaModificacion = proyecto.fechaModificacion
            };
        }

        // Mapeo para INSERTAR
        public static Proyecto MaptoEntity(AgregarProyectoViewModel request)
        {
            return new Proyecto()
            {
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,
                ID_ANIO = request.idAnio,
                ID_ACTIVIDAD_OPERATIVA = request.idActividadOperativa,
                ID_PROGRAMACION_RECURSO = request.idProgramacionRecurso,
                ID_TAREA = request.idTarea,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                ID_UBIGEO = request.idUbigeo,
                TIPO_UBIGEO = request.tipoUbigeo,

                // Montos mensuales
                MONTO_ENERO = request.montoEnero ?? 0,
                MONTO_FEBRERO = request.montoFebrero ?? 0,
                MONTO_MARZO = request.montoMarzo ?? 0,
                MONTO_ABRIL = request.montoAbril ?? 0,
                MONTO_MAYO = request.montoMayo ?? 0,
                MONTO_JUNIO = request.montoJunio ?? 0,
                MONTO_JULIO = request.montoJulio ?? 0,
                MONTO_AGOSTO = request.montoAgosto ?? 0,
                MONTO_SETIEMBRE = request.montoSetiembre ?? 0,
                MONTO_OCTUBRE = request.montoOctubre ?? 0,
                MONTO_NOVIEMBRE = request.montoNoviembre ?? 0,
                MONTO_DICIEMBRE = request.montoDiciembre ?? 0,

                DENOMINACION_RECURSO = request.denominacionRecurso,

                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        // Mapeo para ACTUALIZAR
        public static Proyecto MaptoEntity(ActualizarProyectoViewModel request)
        {
            return new Proyecto()
            {
                ID_PROGRAMACION_PROYECTO = request.idProgramacionProyecto,
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,
                ID_ANIO = request.idAnio,
                ID_ACTIVIDAD_OPERATIVA = request.idActividadOperativa,
                ID_TAREA = request.idTarea,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                ID_UBIGEO = request.idUbigeo,
                TIPO_UBIGEO = request.tipoUbigeo,

                // Montos mensuales
                MONTO_ENERO = request.montoEnero ?? 0,
                MONTO_FEBRERO = request.montoFebrero ?? 0,
                MONTO_MARZO = request.montoMarzo ?? 0,
                MONTO_ABRIL = request.montoAbril ?? 0,
                MONTO_MAYO = request.montoMayo ?? 0,
                MONTO_JUNIO = request.montoJunio ?? 0,
                MONTO_JULIO = request.montoJulio ?? 0,
                MONTO_AGOSTO = request.montoAgosto ?? 0,
                MONTO_SETIEMBRE = request.montoSetiembre ?? 0,
                MONTO_OCTUBRE = request.montoOctubre ?? 0,
                MONTO_NOVIEMBRE = request.montoNoviembre ?? 0,
                MONTO_DICIEMBRE = request.montoDiciembre ?? 0,

                DENOMINACION_RECURSO = request.denominacionRecurso,

                ID_ESTADO = request.idEstado,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para ELIMINAR
        public static Proyecto MaptoEntity(EliminarProyectoViewModel request)
        {
            return new Proyecto()
            {
                ID_PROGRAMACION_PROYECTO = request.idProgramacionProyecto,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para obtener por ID
        public static ObtenerProyectoPorIdResponseViewModel MaptoViewModelPorId(ObtenerProyectoPorIdResponseDTO dto)
        {
            return new ObtenerProyectoPorIdResponseViewModel()
            {
                idProgramacionProyecto = dto.idProgramacionProyecto,
                idProgramacionTareas = dto.idProgramacionTareas,
                idAnio = dto.idAnio,
                idActividadOperativa = dto.idActividadOperativa,
                idTarea = dto.idTarea,
                idUnidadMedida = dto.idUnidadMedida,
                representativa = dto.representativa,
                idFuenteFinanciamiento = dto.idFuenteFinanciamiento,
                idUbigeo = dto.idUbigeo,
                tipoUbigeo = dto.tipoUbigeo,

                // Montos mensuales
                montoEnero = dto.montoEnero,
                montoFebrero = dto.montoFebrero,
                montoMarzo = dto.montoMarzo,
                montoAbril = dto.montoAbril,
                montoMayo = dto.montoMayo,
                montoJunio = dto.montoJunio,
                montoJulio = dto.montoJulio,
                montoAgosto = dto.montoAgosto,
                montoSetiembre = dto.montoSetiembre,
                montoOctubre = dto.montoOctubre,
                montoNoviembre = dto.montoNoviembre,
                montoDiciembre = dto.montoDiciembre,
                montoTotal = dto.montoTotal,

                denominacionRecurso = dto.denominacionRecurso,

                // Datos relacionados
                anio = dto.anio,
                codigoTareas = dto.codigoTareas,
                descripcionTareas = dto.descripcionTareas,
                codigoProgramacion = dto.codigoProgramacion,
                denominacionActividad = dto.denominacionActividad,
                descripcionUnidadMedida = dto.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = dto.descripcionFuenteFinanciamiento,
                descripcionUbigeo = dto.descripcionUbigeo,

                idEstado = dto.idEstado,
                estadoDescripcion = dto.estadoDescripcion,
                activo = dto.activo,
                usuarioCreacion = dto.usuarioCreacion,
                fechaCreacion = dto.fechaCreacion,
                usuarioModificacion = dto.usuarioModificacion,
                fechaModificacion = dto.fechaModificacion
            };
        }
    }
}