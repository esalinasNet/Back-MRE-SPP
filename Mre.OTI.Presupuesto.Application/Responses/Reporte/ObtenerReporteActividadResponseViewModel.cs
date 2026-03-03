using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.Reporte
{
    public class ReporteActividadViewModel
    {
        public int idProgramacionActividad { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public int? idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string centroCostosDescripcion { get; set; }
        public string centroCostosPadre { get; set; }
        public string centroCostosPadreDescripcion { get; set; }
        public string codigoProgramacionActividad { get; set; }
        public string denominacionActividad { get; set; }
        public string descripcionActividad { get; set; }
        public int? idObjetivosInstitucionales { get; set; }
        public string objetivosInstitucionalesDescripcion { get; set; }
        public int? idAccionesInstitucionales { get; set; }
        public string accionesInstitucionalesDescripcion { get; set; }
        public int? idProductoProyecto { get; set; }
        public string productoProyectoDescripcion { get; set; }
        public int? idActividadPresupuestal { get; set; }
        public string actividadPresupuestalDescripcion { get; set; }
        public int? idFuncion { get; set; }
        public string funcionDescripcion { get; set; }
        public int? idDivisionFuncional { get; set; }
        public string divisionFuncionalDescripcion { get; set; }
        public int? idGrupoFuncional { get; set; }
        public string grupoFuncionalDescripcion { get; set; }
        public int? idUnidadMedidaActividad { get; set; }
        public string unidadMedidaActividad { get; set; }
        public string unidadMedidaActividadDescripcion { get; set; }
        public decimal totalEneroActividad { get; set; }
        public decimal totalFebreroActividad { get; set; }
        public decimal totalMarzoActividad { get; set; }
        public decimal totalAbrilActividad { get; set; }
        public decimal totalMayoActividad { get; set; }
        public decimal totalJunioActividad { get; set; }
        public decimal totalJulioActividad { get; set; }
        public decimal totalAgostoActividad { get; set; }
        public decimal totalSetiembreActividad { get; set; }
        public decimal totalOctubreActividad { get; set; }
        public decimal totalNoviembreActividad { get; set; }
        public decimal totalDiciembreActividad { get; set; }
        public decimal totalAnualActividad { get; set; }
    }

    public class ReporteTareaViewModel
    {
        public int idProgramacionTarea { get; set; }
        public int idProgramacionActividadTarea { get; set; }
        public string codigoProgramacionTarea { get; set; }
        public string descripcionTarea { get; set; }
        public int? idUnidadMedidaTarea { get; set; }
        public string unidadMedidaTarea { get; set; }
        public string unidadMedidaTareaDescripcion { get; set; }
        public decimal totalEneroTarea { get; set; }
        public decimal totalFebreroTarea { get; set; }
        public decimal totalMarzoTarea { get; set; }
        public decimal totalAbrilTarea { get; set; }
        public decimal totalMayoTarea { get; set; }
        public decimal totalJunioTarea { get; set; }
        public decimal totalJulioTarea { get; set; }
        public decimal totalAgostoTarea { get; set; }
        public decimal totalSetiembreTarea { get; set; }
        public decimal totalOctubreTarea { get; set; }
        public decimal totalNoviembreTarea { get; set; }
        public decimal totalDiciembreTarea { get; set; }
        public decimal totalAnualTarea { get; set; }
    }

    public class ReporteAccionViewModel
    {
        public int idProgramacionAccion { get; set; }
        public int idProgramacionTareaAccion { get; set; }
        public string codigoProgramacionAccion { get; set; }
        public string descripcionAccion { get; set; }
        public int? idUnidadMedidaAccion { get; set; }
        public string unidadMedidaAccion { get; set; }
        public string unidadMedidaAccionDescripcion { get; set; }
        public decimal? metaFisicaAccion { get; set; }
        public decimal? eneroAccion { get; set; }
        public decimal? febreroAccion { get; set; }
        public decimal? marzoAccion { get; set; }
        public decimal? abrilAccion { get; set; }
        public decimal? mayoAccion { get; set; }
        public decimal? junioAccion { get; set; }
        public decimal? julioAccion { get; set; }
        public decimal? agostoAccion { get; set; }
        public decimal? setiembreAccion { get; set; }
        public decimal? octubreAccion { get; set; }
        public decimal? noviembreAccion { get; set; }
        public decimal? diciembreAccion { get; set; }
        public decimal? totalAnualAccion { get; set; }
    }

    public class ObtenerReporteActividadResponseViewModel
    {
        public ReporteActividadViewModel actividad { get; set; }
        public IEnumerable<ReporteTareaViewModel> tareas { get; set; }
        public IEnumerable<ReporteAccionViewModel> acciones { get; set; }
    }
}