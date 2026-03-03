using Mre.OTI.Presupuesto.Application.DTO.Recurso;
using Mre.OTI.Presupuesto.Application.Features.Recurso.Queries;
using Mre.OTI.Presupuesto.Application.Features.Recurso.Command;
using Mre.OTI.Presupuesto.Application.Responses.Recurso;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class RecursoMap
    {
        public static ObtenerListadoRecursoRequestDTO MaptoRecursoDTO(ObtenerListadoRecursoViewModel item)
        {
            return new ObtenerListadoRecursoRequestDTO()
            {
                idProgramacionTareas = item.idProgramacionTareas,
                usuarioConsulta = item.usuarioConsulta
            };
        }

        public static ObtenerRecursoPaginadoRequestDTO MaptoPaginadoDTO(ObtenerRecursoPaginadoViewModel item)
        {
            return new ObtenerRecursoPaginadoRequestDTO()
            {
                anio = item.anio,
                idProgramacionActividad = item.idProgramacionActividad,
                idProgramacionTareas = item.idProgramacionTareas,
                codigoTareas = item.codigoTareas,
                descripcionTareas = item.descripcionTareas,
                estadoDescripcion = item.estadoDescripcion,
                paginaActual = item.paginaActual,
                tamanioPagina = item.tamanioPagina,
                activo = item.activo
            };
        }

        public static ObtenerListadoRecursoResponseViewModel MaptoViewModel(ObtenerListadoRecursoResponseDTO recurso)
        {
            if (recurso == null) return null;

            return new ObtenerListadoRecursoResponseViewModel()
            {
                idProgramacionRecurso = recurso.idProgramacionRecurso,
                idProgramacionTareas = recurso.idProgramacionTareas,
                idProgramacionActividad = recurso.idProgramacionActividad,
                idAnio = recurso.idAnio,
                anio = recurso.anio,
                codigoTareas = recurso.codigoTareas,
                descripcionTareas = recurso.descripcionTareas,
                codigoProgramacion = recurso.codigoProgramacion,
                denominacionActividad = recurso.denominacionActividad,
                idUbigeo = recurso.idUbigeo,
                descripcionUbigeo = recurso.nombreUbigeo,
                clasificadorGasto = recurso.clasificadorGasto,
                descripcionFuenteFinanciamento = recurso.descripcionFuenteFinanciamento,
                descripcionClasificador = recurso.descripcionClasificador,
                denominacionRecurso = recurso.denominacionRecurso,
                idTipoGasto = recurso.idTipoGasto,
                idTipoItem = recurso.idTipoItem,
                montoTotal = recurso.montoTotal,
                idFuenteFinanciamiento = recurso.idFuenteFinanciamiento,
                descripcionFuenteFinanciamiento = recurso.descripcionFuenteFinanciamiento,
                idUnidadMedida = recurso.idUnidadMedida,
                descripcionUnidadMedida = recurso.descripcionUnidadMedida,
                representativa = recurso.representativa,
                gastoObn = recurso.gastoObn,
                gastoProyecto = recurso.gastoProyecto,
                gastoViaticos = recurso.gastoViaticos,
                gastoCajaChica = recurso.gastoCajaChica,
                gastoOtrosGastos = recurso.gastoOtrosGastos,
                gastoEncargas = recurso.gastoEncargas,
                gastoPlanilla = recurso.gastoPlanilla,
                idEstado = recurso.idEstado,
                estadoDescripcion = recurso.estadoDescripcion,
                activo = recurso.activo,
                usuarioCreacion = recurso.usuarioCreacion,
                fechaCreacion = recurso.fechaCreacion,
                usuarioModificacion = recurso.usuarioModificacion,
                fechaModificacion = recurso.fechaModificacion
            };
        }

        public static Recurso MaptoEntity(AgregarRecursoViewModel request)
        {
            return new Recurso()
            {
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,
                ID_ANIO = request.idAnio,
                ID_UBIGEO = request.idUbigeo,
                CLASIFICADOR_GASTO = request.clasificadorGasto,
                DENOMINACION_RECURSO = request.denominacionRecurso,
                ID_TIPO_GASTO = request.idTipoGasto,
                ID_TIPO_ITEM = request.idTipoItem,
                MONTO_TOTAL = request.montoTotal,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                GASTO_OBN = request.gastoObn ?? false,
                GASTO_PROYECTO = request.gastoProyecto ?? false,
                GASTO_VIATICOS = request.gastoViaticos ?? false,
                GASTO_CAJA_CHICA = request.gastoCajaChica ?? false,
                GASTO_OTROS_GASTOS = request.gastoOtrosGastos ?? false,
                GASTO_ENCARGAS = request.gastoEncargas ?? false,
                GASTO_PLANILLA = request.gastoPlanilla ?? false,
                ID_ESTADO = request.idEstado,
                ipCreacion = request.ipCreacion,
                usuarioCreacion = request.usuarioCreacion,
                fechaCreacion = DateTime.Now
            };
        }

        public static Recurso MaptoEntity(ActualizarRecursoViewModel request)
        {
            return new Recurso()
            {
                ID_PROGRAMACION_RECURSO = request.idProgramacionRecurso,
                ID_PROGRAMACION_ACTIVIDAD = request.idProgramacionActividad,
                ID_PROGRAMACION_TAREAS = request.idProgramacionTareas,
                ID_ANIO = request.idAnio,
                ID_UBIGEO = request.idUbigeo,
                CLASIFICADOR_GASTO = request.clasificadorGasto,
                DENOMINACION_RECURSO = request.denominacionRecurso,
                ID_TIPO_GASTO = request.idTipoGasto,
                ID_TIPO_ITEM = request.idTipoItem,
                MONTO_TOTAL = request.montoTotal,
                ID_FUENTE_FINANCIAMIENTO = request.idFuenteFinanciamiento,
                ID_UNIDAD_MEDIDA = request.idUnidadMedida,
                REPRESENTATIVA = request.representativa,
                GASTO_OBN = request.gastoObn ?? false,
                GASTO_PROYECTO = request.gastoProyecto ?? false,
                GASTO_VIATICOS = request.gastoViaticos ?? false,
                GASTO_CAJA_CHICA = request.gastoCajaChica ?? false,
                GASTO_OTROS_GASTOS = request.gastoOtrosGastos ?? false,
                GASTO_ENCARGAS = request.gastoEncargas ?? false,
                GASTO_PLANILLA = request.gastoPlanilla ?? false,
                ID_ESTADO = request.idEstado,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static Recurso MaptoEntity(EliminarRecursoViewModel request)
        {
            return new Recurso()
            {
                ID_PROGRAMACION_RECURSO = request.idProgramacionRecurso,
                ipModificacion = request.ipModificacion,
                usuarioModificacion = request.usuarioModificacion,
                fechaModificacion = DateTime.Now
            };
        }

        public static ObtenerRecursoPorIdResponseViewModel MaptoViewModelPorId(ObtenerRecursoPorIdResponseDTO dto)
        {
            if (dto == null) return null;

            return new ObtenerRecursoPorIdResponseViewModel()
            {
                idProgramacionRecurso = dto.idProgramacionRecurso,
                idProgramacionTareas = dto.idProgramacionTareas,
                idProgramacionActividad = dto.idProgramacionActividad,
                idAnio = dto.idAnio,
                anio = dto.anio,
                idUbigeo = dto.idUbigeo,
                clasificadorGasto = dto.clasificadorGasto,
                denominacionRecurso = dto.denominacionRecurso,
                idTipoGasto = dto.idTipoGasto,
                idTipoItem = dto.idTipoItem,
                montoTotal = dto.montoTotal,
                idFuenteFinanciamiento = dto.idFuenteFinanciamiento,
                idUnidadMedida = dto.idUnidadMedida,
                representativa = dto.representativa,
                gastoObn = dto.gastoObn,
                gastoProyecto = dto.gastoProyecto,
                gastoViaticos = dto.gastoViaticos,
                gastoCajaChica = dto.gastoCajaChica,
                gastoOtrosGastos = dto.gastoOtrosGastos,
                gastoEncargas = dto.gastoEncargas,
                gastoPlanilla = dto.gastoPlanilla,
                idEstado = dto.idEstado,
                activo = dto.activo,
                usuarioCreacion = dto.usuarioCreacion,
                fechaCreacion = dto.fechaCreacion,
                usuarioModificacion = dto.usuarioModificacion,
                fechaModificacion = dto.fechaModificacion,
                codigoTareas = dto.codigoTareas,
                descripcionTareas = dto.descripcionTareas,
                ubigeoTarea = dto.ubigeoTarea,
                codigoProgramacion = dto.codigoProgramacion,
                denominacionActividad = dto.denominacionActividad,
                descripcionUnidadMedida = dto.descripcionUnidadMedida,
                descripcionFuenteFinanciamiento = dto.descripcionFuenteFinanciamiento,
                descripcionUbigeo = dto.descripcionUbigeo,
                estadoDescripcion = dto.estadoDescripcion
            };
        }
    }
}