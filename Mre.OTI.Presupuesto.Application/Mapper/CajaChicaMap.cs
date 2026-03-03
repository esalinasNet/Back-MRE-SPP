using Mre.OTI.Presupuesto.Application.DTO.CajaChica;
using Mre.OTI.Presupuesto.Application.Features.CajaChica.Queries;
using Mre.OTI.Presupuesto.Application.Features.CajaChica.Command;
using Mre.OTI.Presupuesto.Application.Responses.CajaChica;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class CajaChicaMap
    {
        // Mapeo de ViewModel a RequestDTO (Listado)
        public static ObtenerListadoCajaChicaRequestDTO MaptoCajaChicaDTO(ObtenerListadoCajaChicaViewModel item)
        {
            return new ObtenerListadoCajaChicaRequestDTO()
            {
                idProgramacionRecurso = item.idProgramacionRecurso,
                idProgramacionTareas = item.idProgramacionTareas,
                idAnio = item.idAnio
            };
        }

        // Mapeo para Paginado
        public static ObtenerCajaChicaPaginadoRequestDTO MaptoPaginadoDTO(ObtenerCajaChicaPaginadoViewModel item)
        {
            return new ObtenerCajaChicaPaginadoRequestDTO()
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
        public static ObtenerListadoCajaChicaResponseViewModel MaptoViewModel(dynamic cajaChica)
        {
            return new ObtenerListadoCajaChicaResponseViewModel()
            {
                idProgramacionCajaChica = cajaChica.idProgramacionCajaChica,
                idProgramacionRecurso = cajaChica.idProgramacionRecurso,
                idProgramacionTareas = cajaChica.idProgramacionTareas,
                idAnio = cajaChica.idAnio,
                idActividadOperativa = cajaChica.idActividadOperativa,
                idTarea = cajaChica.idTarea,
                idUnidadMedida = cajaChica.idUnidadMedida,
                representativa = cajaChica.representativa,
                idFuenteFinanciamiento = cajaChica.idFuenteFinanciamiento,
                idUbigeo = cajaChica.idUbigeo,
                tipoUbigeo = cajaChica.tipoUbigeo,

                // Montos mensuales
                montoEnero = cajaChica.montoEnero,
                montoFebrero = cajaChica.montoFebrero,
                montoMarzo = cajaChica.montoMarzo,
                montoAbril = cajaChica.montoAbril,
                montoMayo = cajaChica.montoMayo,
                montoJunio = cajaChica.montoJunio,
                montoJulio = cajaChica.montoJulio,
                montoAgosto = cajaChica.montoAgosto,
                montoSetiembre = cajaChica.montoSetiembre,
                montoOctubre = cajaChica.montoOctubre,
                montoNoviembre = cajaChica.montoNoviembre,
                montoDiciembre = cajaChica.montoDiciembre,
                montoTotal = cajaChica.montoTotal,

                // Datos relacionados
                anio = cajaChica.anio,
                codigoTareas = cajaChica.codigoTareas,
                descripcionTareas = cajaChica.descripcionTareas,
                codigoProgramacion = cajaChica.codigoProgramacion,
                denominacionActividad = cajaChica.denominacionActividad,
                descripcionUnidadMedida = cajaChica.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = cajaChica.descripcionFuenteFinanciamiento,
                descripcionUbigeo = cajaChica.descripcionUbigeo,

                idEstado = cajaChica.idEstado,
                estado = cajaChica.estado,
                estadoDescripcion = cajaChica.estadoDescripcion,
                activo = cajaChica.activo,
                usuarioCreacion = cajaChica.usuarioCreacion,
                fechaCreacion = cajaChica.fechaCreacion,
                usuarioModificacion = cajaChica.usuarioModificacion,
                fechaModificacion = cajaChica.fechaModificacion
            };
        }

        // Mapeo para INSERTAR
        public static CajaChica MaptoEntity(AgregarCajaChicaViewModel request)
        {
            return new CajaChica()
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
        public static CajaChica MaptoEntity(ActualizarCajaChicaViewModel request)
        {
            return new CajaChica()
            {
                ID_PROGRAMACION_CAJA_CHICA = request.idProgramacionCajaChica,
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
        public static CajaChica MaptoEntity(EliminarCajaChicaViewModel request)
        {
            return new CajaChica()
            {
                ID_PROGRAMACION_CAJA_CHICA = request.idProgramacionCajaChica,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        // Mapeo para obtener por ID
        public static ObtenerCajaChicaPorIdResponseViewModel MaptoViewModelPorId(ObtenerCajaChicaPorIdResponseDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ObtenerCajaChicaPorIdResponseViewModel()
            {
                idProgramacionCajaChica = dto.idProgramacionCajaChica,
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