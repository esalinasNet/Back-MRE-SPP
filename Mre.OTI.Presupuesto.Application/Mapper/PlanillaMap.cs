using Mre.OTI.Presupuesto.Application.DTO.Planilla;
using Mre.OTI.Presupuesto.Application.Features.Planilla.Queries;
using Mre.OTI.Presupuesto.Application.Features.Planilla.Command;
using Mre.OTI.Presupuesto.Application.Responses.Planilla;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class PlanillaMap
    {
        // Mapeo de ViewModel a RequestDTO (Listado)
        public static ObtenerListadoPlanillaRequestDTO MaptoPlanillaDTO(ObtenerListadoPlanillaViewModel item)
        {
            return new ObtenerListadoPlanillaRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                idAnio = item.idAnio
            };
        }

        // Mapeo para Paginado
        public static ObtenerPlanillaPaginadoRequestDTO MaptoPaginadoDTO(ObtenerPlanillaPaginadoViewModel item)
        {
            return new ObtenerPlanillaPaginadoRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                anio = item.anio,
                tipoUbigeo = item.tipoUbigeo,
                nombreTrabajador = item.nombreTrabajador,
                cargo = item.cargo,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        // Mapeo de Entity/Dynamic a ResponseViewModel (Listado)
        public static ObtenerListadoPlanillaResponseViewModel MaptoViewModel(dynamic planilla)
        {
            return new ObtenerListadoPlanillaResponseViewModel()
            {
                idProgramacionPlanilla = planilla.idProgramacionPlanilla,
                idProgramacionRecurso = planilla.idProgramacionRecurso,
                idProgramacionTareas = planilla.idProgramacionTareas,
                idAnio = planilla.idAnio,
                idActividadOperativa = planilla.idActividadOperativa,
                idTarea = planilla.idTarea,
                idUnidadMedida = planilla.idUnidadMedida,
                representativa = planilla.representativa,
                idFuenteFinanciamiento = planilla.idFuenteFinanciamiento,
                idUbigeo = planilla.idUbigeo,
                tipoUbigeo = planilla.tipoUbigeo,

                // Datos del trabajador y clasificador
                idTrabajador = planilla.idTrabajador,
                nombreTrabajador = planilla.nombreTrabajador,
                cargo = planilla.cargo,
                idClasificador = planilla.idClasificador,
                codigoClasificador = planilla.codigoClasificador,
                descripcionClasificador = planilla.descripcionClasificador,

                // Montos mensuales
                montoEnero = planilla.montoEnero,
                montoFebrero = planilla.montoFebrero,
                montoMarzo = planilla.montoMarzo,
                montoAbril = planilla.montoAbril,
                montoMayo = planilla.montoMayo,
                montoJunio = planilla.montoJunio,
                montoJulio = planilla.montoJulio,
                montoAgosto = planilla.montoAgosto,
                montoSetiembre = planilla.montoSetiembre,
                montoOctubre = planilla.montoOctubre,
                montoNoviembre = planilla.montoNoviembre,
                montoDiciembre = planilla.montoDiciembre,
                montoTotal = planilla.montoTotal,

                // Datos relacionados
                anio = planilla.anio,
                codigoTareas = planilla.codigoTareas,
                descripcionTareas = planilla.descripcionTareas,
                codigoProgramacion = planilla.codigoProgramacion,
                denominacionActividad = planilla.denominacionActividad,
                descripcionUnidadMedida = planilla.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = planilla.descripcionFuenteFinanciamiento,
                descripcionUbigeo = planilla.descripcionUbigeo,

                idEstado = planilla.idEstado,
                estado = planilla.estado,
                estadoDescripcion = planilla.estadoDescripcion,
                activo = planilla.activo,
                usuarioCreacion = planilla.usuarioCreacion,
                fechaCreacion = planilla.fechaCreacion,
                usuarioModificacion = planilla.usuarioModificacion,
                fechaModificacion = planilla.fechaModificacion
            };
        }

        // Mapeo para INSERTAR
        public static Planilla MaptoEntity(AgregarPlanillaViewModel request)
        {
            return new Planilla()
            {
                ID_PROGRAMACION_RECURSO = request.idProgramacionRecurso,
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,
                ID_ANIO = request.idAnio,
                ID_ACTIVIDAD_OPERATIVA = request.idActividadOperativa,
                ID_TAREA = request.idTarea,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                ID_UBIGEO = request.idUbigeo,
                TIPO_UBIGEO = request.tipoUbigeo,

                // Datos del trabajador y clasificador
                ID_TRABAJADOR = request.idTrabajador,
                NOMBRE_TRABAJADOR = request.nombreTrabajador,
                CARGO = request.cargo,
                ID_CLASIFICADOR = request.idClasificador,
                CODIGO_CLASIFICADOR = request.codigoClasificador,
                DESCRIPCION_CLASIFICADOR = request.descripcionClasificador,

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

                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        // Mapeo para ACTUALIZAR
        public static Planilla MaptoEntity(ActualizarPlanillaViewModel request)
        {
            return new Planilla()
            {
                ID_PROGRAMACION_PLANILLA = request.idProgramacionPlanilla,
                ID_PROGRAMACION_RECURSO = request.idProgramacionRecurso,
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,
                ID_ANIO = request.idAnio,
                ID_ACTIVIDAD_OPERATIVA = request.idActividadOperativa,
                ID_TAREA = request.idTarea,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                ID_UBIGEO = request.idUbigeo,
                TIPO_UBIGEO = request.tipoUbigeo,

                // Datos del trabajador y clasificador
                ID_TRABAJADOR = request.idTrabajador,
                NOMBRE_TRABAJADOR = request.nombreTrabajador,
                CARGO = request.cargo,
                ID_CLASIFICADOR = request.idClasificador,
                CODIGO_CLASIFICADOR = request.codigoClasificador,
                DESCRIPCION_CLASIFICADOR = request.descripcionClasificador,

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

                ID_ESTADO = request.idEstado,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para ELIMINAR
        public static Planilla MaptoEntity(EliminarPlanillaViewModel request)
        {
            return new Planilla()
            {
                ID_PROGRAMACION_PLANILLA = request.idProgramacionPlanilla,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para obtener por ID
        public static ObtenerPlanillaPorIdResponseViewModel MaptoViewModelPorId(ObtenerPlanillaPorIdResponseDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ObtenerPlanillaPorIdResponseViewModel()
            {
                idProgramacionPlanilla = dto.idProgramacionPlanilla,
                idProgramacionRecurso = dto.idProgramacionRecurso,
                idProgramacionTareas = dto.idProgramacionTareas,
                idAnio = dto.idAnio,
                idActividadOperativa = dto.idActividadOperativa,
                idTarea = dto.idTarea,
                idUnidadMedida = dto.idUnidadMedida,
                representativa = dto.representativa,
                idFuenteFinanciamiento = dto.idFuenteFinanciamiento,
                idUbigeo = dto.idUbigeo,
                tipoUbigeo = dto.tipoUbigeo,

                // Datos del trabajador y clasificador
                idTrabajador = dto.idTrabajador,
                nombreTrabajador = dto.nombreTrabajador,
                cargo = dto.cargo,
                idClasificador = dto.idClasificador,
                codigoClasificador = dto.codigoClasificador,
                descripcionClasificador = dto.descripcionClasificador,

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
                estado = dto.estado,
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