using Mre.OTI.Presupuesto.Application.DTO.Viaticos;
using Mre.OTI.Presupuesto.Application.Features.Viaticos.Queries;
using Mre.OTI.Presupuesto.Application.Features.Viaticos.Command;
using Mre.OTI.Presupuesto.Application.Responses.Viaticos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ViaticosMap
    {
        // Mapeo de ViewModel a RequestDTO (Listado)
        public static ObtenerListadoViaticosRequestDTO MaptoViaticosDTO(ObtenerListadoViaticosViewModel item)
        {
            return new ObtenerListadoViaticosRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                idAnio = item.idAnio
            };
        }

        // Mapeo para Paginado
        public static ObtenerViaticoPaginadoRequestDTO MaptoPaginadoDTO(ObtenerViaticoPaginadoViewModel item)
        {
            return new ObtenerViaticoPaginadoRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                anio = item.anio,
                tipoUbigeo = item.tipoUbigeo,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        // Mapeo de Entity/Dynamic a ResponseViewModel (Listado)
        public static ObtenerListadoViaticosResponseViewModel MaptoViewModel(dynamic viatico)
        {
            return new ObtenerListadoViaticosResponseViewModel()
            {
                idProgramacionViaticos = viatico.idProgramacionViaticos,
                idProgramacionRecurso = viatico.idProgramacionRecurso,
                idProgramacionTareas = viatico.idProgramacionTareas,
                idAnio = viatico.idAnio,
                idActividadOperativa = viatico.idActividadOperativa,
                idTarea = viatico.idTarea,
                idUnidadMedida = viatico.idUnidadMedida,
                representativa = viatico.representativa,
                idFuenteFinanciamiento = viatico.idFuenteFinanciamiento,
                idUbigeo = viatico.idUbigeo,
                tipoUbigeo = viatico.tipoUbigeo,

                // Montos mensuales
                montoEnero = viatico.montoEnero,
                montoFebrero = viatico.montoFebrero,
                montoMarzo = viatico.montoMarzo,
                montoAbril = viatico.montoAbril,
                montoMayo = viatico.montoMayo,
                montoJunio = viatico.montoJunio,
                montoJulio = viatico.montoJulio,
                montoAgosto = viatico.montoAgosto,
                montoSetiembre = viatico.montoSetiembre,
                montoOctubre = viatico.montoOctubre,
                montoNoviembre = viatico.montoNoviembre,
                montoDiciembre = viatico.montoDiciembre,
                montoTotal = viatico.montoTotal,

                // ✅ Campos específicos de Viáticos
                clasificadorGasto = viatico.clasificadorGasto,
                denominacionRecurso = viatico.denominacionRecurso,
                montoDiario = viatico.montoDiario,
                dias = viatico.dias,
                cantidadPersonas = viatico.cantidadPersonas,

                // Datos relacionados
                anio = viatico.anio,
                codigoTareas = viatico.codigoTareas,
                descripcionTareas = viatico.descripcionTareas,
                codigoProgramacion = viatico.codigoProgramacion,
                denominacionActividad = viatico.denominacionActividad,
                descripcionUnidadMedida = viatico.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = viatico.descripcionFuenteFinanciamiento,
                descripcionUbigeo = viatico.descripcionUbigeo,

                idEstado = viatico.idEstado,
                estado = viatico.estado,
                estadoDescripcion = viatico.estadoDescripcion,
                activo = viatico.activo,
                usuarioCreacion = viatico.usuarioCreacion,
                fechaCreacion = viatico.fechaCreacion,
                usuarioModificacion = viatico.usuarioModificacion,
                fechaModificacion = viatico.fechaModificacion
            };
        }

        // Mapeo para INSERTAR
        public static Viaticos MaptoEntity(AgregarViaticosViewModel request)
        {
            return new Viaticos()
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

                // ✅ Campos específicos de Viáticos
                CLASIFICADOR_GASTO = request.clasificadorGasto,
                DENOMINACION_RECURSO = request.denominacionRecurso,
                MONTO_DIARIO = request.montoDiario,
                DIAS = request.dias,
                CANTIDAD_PERSONAS = request.cantidadPersonas,

                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        // Mapeo para ACTUALIZAR
        public static Viaticos MaptoEntity(ActualizarViaticosViewModel request)
        {
            return new Viaticos()
            {
                ID_PROGRAMACION_VIATICOS = request.idProgramacionViaticos,
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

                // ✅ Campos específicos de Viáticos
                CLASIFICADOR_GASTO = request.clasificadorGasto,
                DENOMINACION_RECURSO = request.denominacionRecurso,
                MONTO_DIARIO = request.montoDiario,
                DIAS = request.dias,
                CANTIDAD_PERSONAS = request.cantidadPersonas,

                ID_ESTADO = request.idEstado,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para ELIMINAR
        public static Viaticos MaptoEntity(EliminarViaticosViewModel request)
        {
            return new Viaticos()
            {
                ID_PROGRAMACION_VIATICOS = request.idProgramacionViaticos,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para obtener por ID
        public static ObtenerViaticoPorIdResponseViewModel MaptoViewModelPorId(ObtenerViaticoPorIdResponseDTO dto)
        {
            return new ObtenerViaticoPorIdResponseViewModel()
            {
                idProgramacionViaticos = dto.idProgramacionViaticos,
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

                // ✅ Campos específicos de Viáticos
                clasificadorGasto = dto.clasificadorGasto,
                denominacionRecurso = dto.denominacionRecurso,
                montoDiario = dto.montoDiario,
                dias = dto.dias,
                cantidadPersonas = dto.cantidadPersonas,

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