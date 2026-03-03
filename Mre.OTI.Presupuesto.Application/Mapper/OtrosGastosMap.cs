using Mre.OTI.Presupuesto.Application.DTO.OtrosGastos;
using Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Queries;
using Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Command;
using Mre.OTI.Presupuesto.Application.Responses.OtrosGastos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class OtrosGastosMap
    {
        // Mapeo de ViewModel a RequestDTO (Listado)
        public static ObtenerListadoOtrosGastosRequestDTO MaptoOtrosGastosDTO(ObtenerListadoOtrosGastosViewModel item)
        {
            return new ObtenerListadoOtrosGastosRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                idAnio = item.idAnio
            };
        }

        // Mapeo para Paginado
        public static ObtenerOtrosGastosPaginadoRequestDTO MaptoPaginadoDTO(ObtenerOtrosGastosPaginadoViewModel item)
        {
            return new ObtenerOtrosGastosPaginadoRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                anio = item.anio,
                idGenerico = item.idGenerico,
                tipoUbigeo = item.tipoUbigeo,
                denominacionRecurso = item.denominacionRecurso,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        // Mapeo de Entity/Dynamic a ResponseViewModel (Listado)
        public static ObtenerListadoOtrosGastosResponseViewModel MaptoViewModel(dynamic otrosGastos)
        {
            return new ObtenerListadoOtrosGastosResponseViewModel()
            {
                idProgramacionOtrosGastos = otrosGastos.idProgramacionOtrosGastos,
                idProgramacionRecurso = otrosGastos.idProgramacionRecurso,
                idProgramacionTareas = otrosGastos.idProgramacionTareas,
                idAnio = otrosGastos.idAnio,
                idActividadOperativa = otrosGastos.idActividadOperativa,
                idTarea = otrosGastos.idTarea,
                idUnidadMedida = otrosGastos.idUnidadMedida,
                representativa = otrosGastos.representativa,
                idFuenteFinanciamiento = otrosGastos.idFuenteFinanciamiento,
                idUbigeo = otrosGastos.idUbigeo,
                tipoUbigeo = otrosGastos.tipoUbigeo,

                // Montos mensuales
                montoEnero = otrosGastos.montoEnero,
                montoFebrero = otrosGastos.montoFebrero,
                montoMarzo = otrosGastos.montoMarzo,
                montoAbril = otrosGastos.montoAbril,
                montoMayo = otrosGastos.montoMayo,
                montoJunio = otrosGastos.montoJunio,
                montoJulio = otrosGastos.montoJulio,
                montoAgosto = otrosGastos.montoAgosto,
                montoSetiembre = otrosGastos.montoSetiembre,
                montoOctubre = otrosGastos.montoOctubre,
                montoNoviembre = otrosGastos.montoNoviembre,
                montoDiciembre = otrosGastos.montoDiciembre,
                montoTotal = otrosGastos.montoTotal,

                // ✅ Campos específicos de Otros Gastos
                idGenerico = otrosGastos.idGenerico,
                clasificadorGasto = otrosGastos.clasificadorGasto,
                denominacionRecurso = otrosGastos.denominacionRecurso,
                valor = otrosGastos.valor,

                // Datos relacionados
                anio = otrosGastos.anio,
                codigoTareas = otrosGastos.codigoTareas,
                descripcionTareas = otrosGastos.descripcionTareas,
                codigoProgramacion = otrosGastos.codigoProgramacion,
                denominacionActividad = otrosGastos.denominacionActividad,
                descripcionUnidadMedida = otrosGastos.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = otrosGastos.descripcionFuenteFinanciamiento,
                descripcionUbigeo = otrosGastos.descripcionUbigeo,

                idEstado = otrosGastos.idEstado,
                estado = otrosGastos.estado,
                estadoDescripcion = otrosGastos.estadoDescripcion,
                activo = otrosGastos.activo,
                usuarioCreacion = otrosGastos.usuarioCreacion,
                fechaCreacion = otrosGastos.fechaCreacion,
                usuarioModificacion = otrosGastos.usuarioModificacion,
                fechaModificacion = otrosGastos.fechaModificacion
            };
        }

        // Mapeo para INSERTAR
        public static OtrosGastos MaptoEntity(AgregarOtrosGastosViewModel request)
        {
            return new OtrosGastos()
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

                // ✅ Campos específicos de Otros Gastos
                ID_GENERICO = request.idGenerico,
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
        public static OtrosGastos MaptoEntity(ActualizarOtrosGastosViewModel request)
        {
            return new OtrosGastos()
            {
                ID_PROGRAMACION_OTROS_GASTOS = request.idProgramacionOtrosGastos,
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

                // ✅ Campos específicos de Otros Gastos
                ID_GENERICO = request.idGenerico,
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
        public static OtrosGastos MaptoEntity(EliminarOtrosGastosViewModel request)
        {
            return new OtrosGastos()
            {
                ID_PROGRAMACION_OTROS_GASTOS = request.idProgramacionOtrosGastos,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para obtener por ID
        public static ObtenerOtrosGastosPorIdResponseViewModel MaptoViewModelPorId(ObtenerOtrosGastosPorIdResponseDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ObtenerOtrosGastosPorIdResponseViewModel()
            {
                idProgramacionOtrosGastos = dto.idProgramacionOtrosGastos,
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

                // ✅ Campos específicos de Otros Gastos
                idGenerico = dto.idGenerico,
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