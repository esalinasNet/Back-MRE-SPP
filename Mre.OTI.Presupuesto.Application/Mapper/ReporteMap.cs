using Mre.OTI.Presupuesto.Application.DTO.Reporte;
using Mre.OTI.Presupuesto.Application.Responses.Reporte;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Mapper
{
    public class ReporteMap
    {
        public static ObtenerReporteActividadResponseViewModel MaptoViewModel(ObtenerReporteActividadResponseDTO dto)
        {
            if (dto?.actividad == null) return null;

            return new ObtenerReporteActividadResponseViewModel
            {
                actividad = new ReporteActividadViewModel
                {
                    idProgramacionActividad = dto.actividad.idProgramacionActividad,
                    idAnio = dto.actividad.idAnio,
                    anio = dto.actividad.anio,
                    idCentroCostos = dto.actividad.idCentroCostos,
                    centroCostos = dto.actividad.centroCostos,
                    centroCostosDescripcion = dto.actividad.centroCostosDescripcion,
                    centroCostosPadre = dto.actividad.centroCostosPadre,
                    centroCostosPadreDescripcion = dto.actividad.centroCostosPadreDescripcion,
                    codigoProgramacionActividad = dto.actividad.codigoProgramacionActividad,
                    denominacionActividad = dto.actividad.denominacionActividad,
                    descripcionActividad = dto.actividad.descripcionActividad,
                    idObjetivosInstitucionales = dto.actividad.idObjetivosInstitucionales,
                    objetivosInstitucionalesDescripcion = dto.actividad.objetivosInstitucionalesDescripcion,
                    idAccionesInstitucionales = dto.actividad.idAccionesInstitucionales,
                    accionesInstitucionalesDescripcion = dto.actividad.accionesInstitucionalesDescripcion,
                    idProductoProyecto = dto.actividad.idProductoProyecto,
                    productoProyectoDescripcion = dto.actividad.productoProyectoDescripcion,
                    idActividadPresupuestal = dto.actividad.idActividadPresupuestal,
                    actividadPresupuestalDescripcion = dto.actividad.actividadPresupuestalDescripcion,
                    idFuncion = dto.actividad.idFuncion,
                    funcionDescripcion = dto.actividad.funcionDescripcion,
                    idDivisionFuncional = dto.actividad.idDivisionFuncional,
                    divisionFuncionalDescripcion = dto.actividad.divisionFuncionalDescripcion,
                    idGrupoFuncional = dto.actividad.idGrupoFuncional,
                    grupoFuncionalDescripcion = dto.actividad.grupoFuncionalDescripcion,
                    idUnidadMedidaActividad = dto.actividad.idUnidadMedidaActividad,
                    unidadMedidaActividad = dto.actividad.unidadMedidaActividad,
                    unidadMedidaActividadDescripcion = dto.actividad.unidadMedidaActividadDescripcion,
                    totalEneroActividad = dto.actividad.totalEneroActividad,
                    totalFebreroActividad = dto.actividad.totalFebreroActividad,
                    totalMarzoActividad = dto.actividad.totalMarzoActividad,
                    totalAbrilActividad = dto.actividad.totalAbrilActividad,
                    totalMayoActividad = dto.actividad.totalMayoActividad,
                    totalJunioActividad = dto.actividad.totalJunioActividad,
                    totalJulioActividad = dto.actividad.totalJulioActividad,
                    totalAgostoActividad = dto.actividad.totalAgostoActividad,
                    totalSetiembreActividad = dto.actividad.totalSetiembreActividad,
                    totalOctubreActividad = dto.actividad.totalOctubreActividad,
                    totalNoviembreActividad = dto.actividad.totalNoviembreActividad,
                    totalDiciembreActividad = dto.actividad.totalDiciembreActividad,
                    totalAnualActividad = dto.actividad.totalAnualActividad
                },

                tareas = dto.tareas?.Select(t => new ReporteTareaViewModel
                {
                    idProgramacionTarea = t.idProgramacionTarea,
                    idProgramacionActividadTarea = t.idProgramacionActividadTarea,
                    codigoProgramacionTarea = t.codigoProgramacionTarea,
                    descripcionTarea = t.descripcionTarea,
                    idUnidadMedidaTarea = t.idUnidadMedidaTarea,
                    unidadMedidaTarea = t.unidadMedidaTarea,
                    unidadMedidaTareaDescripcion = t.unidadMedidaTareaDescripcion,
                    totalEneroTarea = t.totalEneroTarea,
                    totalFebreroTarea = t.totalFebreroTarea,
                    totalMarzoTarea = t.totalMarzoTarea,
                    totalAbrilTarea = t.totalAbrilTarea,
                    totalMayoTarea = t.totalMayoTarea,
                    totalJunioTarea = t.totalJunioTarea,
                    totalJulioTarea = t.totalJulioTarea,
                    totalAgostoTarea = t.totalAgostoTarea,
                    totalSetiembreTarea = t.totalSetiembreTarea,
                    totalOctubreTarea = t.totalOctubreTarea,
                    totalNoviembreTarea = t.totalNoviembreTarea,
                    totalDiciembreTarea = t.totalDiciembreTarea,
                    totalAnualTarea = t.totalAnualTarea
                }),

                acciones = dto.acciones?.Select(a => new ReporteAccionViewModel
                {
                    idProgramacionAccion = a.idProgramacionAccion,
                    idProgramacionTareaAccion = a.idProgramacionTareaAccion,
                    codigoProgramacionAccion = a.codigoProgramacionAccion,
                    descripcionAccion = a.descripcionAccion,
                    idUnidadMedidaAccion = a.idUnidadMedidaAccion,
                    unidadMedidaAccion = a.unidadMedidaAccion,
                    unidadMedidaAccionDescripcion = a.unidadMedidaAccionDescripcion,
                    metaFisicaAccion = a.metaFisicaAccion,
                    eneroAccion = a.eneroAccion,
                    febreroAccion = a.febreroAccion,
                    marzoAccion = a.marzoAccion,
                    abrilAccion = a.abrilAccion,
                    mayoAccion = a.mayoAccion,
                    junioAccion = a.junioAccion,
                    julioAccion = a.julioAccion,
                    agostoAccion = a.agostoAccion,
                    setiembreAccion = a.setiembreAccion,
                    octubreAccion = a.octubreAccion,
                    noviembreAccion = a.noviembreAccion,
                    diciembreAccion = a.diciembreAccion,
                    totalAnualAccion = a.totalAnualAccion
                })
            };
        }
    }
}