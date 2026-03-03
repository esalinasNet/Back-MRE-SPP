using Mre.OTI.Presupuesto.Application.DTO.Encargos;
using Mre.OTI.Presupuesto.Application.Features.Encargos.Queries;
using Mre.OTI.Presupuesto.Application.Features.Encargos.Command;
using Mre.OTI.Presupuesto.Application.Responses.Encargos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class EncargosMap
    {
        // Mapeo de ViewModel a RequestDTO (Listado)
        public static ObtenerListadoEncargosRequestDTO MaptoEncargosDTO(ObtenerListadoEncargosViewModel item)
        {
            return new ObtenerListadoEncargosRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                idAnio = item.idAnio
            };
        }

        // Mapeo para Paginado
        public static ObtenerEncargosPaginadoRequestDTO MaptoPaginadoDTO(ObtenerEncargosPaginadoViewModel item)
        {
            return new ObtenerEncargosPaginadoRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                anio = item.anio,
                tipoUbigeo = item.tipoUbigeo,
                denominacionRecurso = item.denominacionRecurso,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        // Mapeo de Entity/Dynamic a ResponseViewModel (Listado)
        public static ObtenerListadoEncargosResponseViewModel MaptoViewModel(dynamic encargos)
        {
            return new ObtenerListadoEncargosResponseViewModel()
            {
                idProgramacionEncargos = encargos.idProgramacionEncargos,
                idProgramacionRecurso = encargos.idProgramacionRecurso,
                idProgramacionTareas = encargos.idProgramacionTareas,
                idAnio = encargos.idAnio,
                idActividadOperativa = encargos.idActividadOperativa,
                idTarea = encargos.idTarea,
                idUnidadMedida = encargos.idUnidadMedida,
                representativa = encargos.representativa,
                idFuenteFinanciamiento = encargos.idFuenteFinanciamiento,
                idUbigeo = encargos.idUbigeo,
                tipoUbigeo = encargos.tipoUbigeo,

                // Montos mensuales
                montoEnero = encargos.montoEnero,
                montoFebrero = encargos.montoFebrero,
                montoMarzo = encargos.montoMarzo,
                montoAbril = encargos.montoAbril,
                montoMayo = encargos.montoMayo,
                montoJunio = encargos.montoJunio,
                montoJulio = encargos.montoJulio,
                montoAgosto = encargos.montoAgosto,
                montoSetiembre = encargos.montoSetiembre,
                montoOctubre = encargos.montoOctubre,
                montoNoviembre = encargos.montoNoviembre,
                montoDiciembre = encargos.montoDiciembre,
                montoTotal = encargos.montoTotal,

                // Campos específicos de Encargos
                clasificadorGasto = encargos.clasificadorGasto,
                denominacionRecurso = encargos.denominacionRecurso,
                valor = encargos.valor,

                // Datos relacionados
                anio = encargos.anio,
                codigoTareas = encargos.codigoTareas,
                descripcionTareas = encargos.descripcionTareas,
                codigoProgramacion = encargos.codigoProgramacion,
                denominacionActividad = encargos.denominacionActividad,
                descripcionUnidadMedida = encargos.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = encargos.descripcionFuenteFinanciamiento,
                descripcionUbigeo = encargos.descripcionUbigeo,

                idEstado = encargos.idEstado,
                estado = encargos.estado,
                estadoDescripcion = encargos.estadoDescripcion,
                activo = encargos.activo,
                usuarioCreacion = encargos.usuarioCreacion,
                fechaCreacion = encargos.fechaCreacion,
                usuarioModificacion = encargos.usuarioModificacion,
                fechaModificacion = encargos.fechaModificacion
            };
        }

        // Mapeo para INSERTAR
        public static Encargos MaptoEntity(AgregarEncargosViewModel request)
        {
            return new Encargos()
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

                // Campos específicos de Encargos
                CLASIFICADOR_GASTO = request.clasificadorGasto,
                DENOMINACION_RECURSO = request.denominacionRecurso,
                VALOR = request.valor,

                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        // Mapeo para ACTUALIZAR
        public static Encargos MaptoEntity(ActualizarEncargosViewModel request)
        {
            return new Encargos()
            {
                ID_PROGRAMACION_ENCARGOS = request.idProgramacionEncargos,
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

                // Campos específicos de Encargos
                CLASIFICADOR_GASTO = request.clasificadorGasto,
                DENOMINACION_RECURSO = request.denominacionRecurso,
                VALOR = request.valor,

                ID_ESTADO = request.idEstado,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para ELIMINAR
        public static Encargos MaptoEntity(EliminarEncargosViewModel request)
        {
            return new Encargos()
            {
                ID_PROGRAMACION_ENCARGOS = request.idProgramacionEncargos,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para obtener por ID
        public static ObtenerEncargosPorIdResponseViewModel MaptoViewModelPorId(ObtenerEncargosPorIdResponseDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ObtenerEncargosPorIdResponseViewModel()
            {
                idProgramacionEncargos = dto.idProgramacionEncargos,
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

                // Campos específicos de Encargos
                clasificadorGasto = dto.clasificadorGasto,
                denominacionRecurso = dto.denominacionRecurso,
                valor = dto.valor,

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