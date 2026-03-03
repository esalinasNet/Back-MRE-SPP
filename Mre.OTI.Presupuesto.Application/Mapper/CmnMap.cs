using Mre.OTI.Presupuesto.Application.DTO.Cmn;
using Mre.OTI.Presupuesto.Application.Features.Cmn.Queries;
using Mre.OTI.Presupuesto.Application.Features.Cmn.Command;
using Mre.OTI.Presupuesto.Application.Responses.Cmn;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class CmnMap
    {
        // Mapeo de ViewModel a RequestDTO (Listado)
        public static ObtenerListadoCmnRequestDTO MaptoCmnDTO(ObtenerListadoCmnViewModel item)
        {
            return new ObtenerListadoCmnRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                idAnio = item.idAnio
            };
        }

        // Mapeo para Paginado
        public static ObtenerCmnPaginadoRequestDTO MaptoPaginadoDTO(ObtenerCmnPaginadoViewModel item)
        {
            return new ObtenerCmnPaginadoRequestDTO()
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
        public static ObtenerListadoCmnResponseViewModel MaptoViewModel(dynamic cmn)
        {
            return new ObtenerListadoCmnResponseViewModel()
            {
                idProgramacionCmn = cmn.idProgramacionCmn,
                idProgramacionRecurso = cmn.idProgramacionRecurso,
                idProgramacionTareas = cmn.idProgramacionTareas,
                idAnio = cmn.idAnio,
                idActividadOperativa = cmn.idActividadOperativa,
                idTarea = cmn.idTarea,
                idUnidadMedida = cmn.idUnidadMedida,
                representativa = cmn.representativa,
                idFuenteFinanciamiento = cmn.idFuenteFinanciamiento,
                idUbigeo = cmn.idUbigeo,
                tipoUbigeo = cmn.tipoUbigeo,

                // Montos mensuales
                montoEnero = cmn.montoEnero,
                montoFebrero = cmn.montoFebrero,
                montoMarzo = cmn.montoMarzo,
                montoAbril = cmn.montoAbril,
                montoMayo = cmn.montoMayo,
                montoJunio = cmn.montoJunio,
                montoJulio = cmn.montoJulio,
                montoAgosto = cmn.montoAgosto,
                montoSetiembre = cmn.montoSetiembre,
                montoOctubre = cmn.montoOctubre,
                montoNoviembre = cmn.montoNoviembre,
                montoDiciembre = cmn.montoDiciembre,
                montoTotal = cmn.montoTotal,

                // Datos relacionados
                anio = cmn.anio,
                codigoTareas = cmn.codigoTareas,
                descripcionTareas = cmn.descripcionTareas,
                codigoProgramacion = cmn.codigoProgramacion,
                denominacionActividad = cmn.denominacionActividad,
                descripcionUnidadMedida = cmn.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = cmn.descripcionFuenteFinanciamiento,
                descripcionUbigeo = cmn.descripcionUbigeo,

                idEstado = cmn.idEstado,
                estado = cmn.estado,
                estadoDescripcion = cmn.estadoDescripcion,
                activo = cmn.activo,
                usuarioCreacion = cmn.usuarioCreacion,
                fechaCreacion = cmn.fechaCreacion,
                usuarioModificacion = cmn.usuarioModificacion,
                fechaModificacion = cmn.fechaModificacion
            };
        }

        // Mapeo para INSERTAR
        public static Cmn MaptoEntity(AgregarCmnViewModel request)
        {
            return new Cmn()
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

                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        // Mapeo para ACTUALIZAR
        public static Cmn MaptoEntity(ActualizarCmnViewModel request)
        {
            return new Cmn()
            {
                ID_PROGRAMACION_CMN = request.idProgramacionCmn,
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

                ID_ESTADO = request.idEstado,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para ELIMINAR
        public static Cmn MaptoEntity(EliminarCmnViewModel request)
        {
            return new Cmn()
            {
                ID_PROGRAMACION_CMN = request.idProgramacionCmn,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para obtener por ID
        public static ObtenerCmnPorIdResponseViewModel MaptoViewModelPorId(ObtenerCmnPorIdResponseDTO dto)
        {
            return new ObtenerCmnPorIdResponseViewModel()
            {
                idProgramacionCmn = dto.idProgramacionCmn,
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