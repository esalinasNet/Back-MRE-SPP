using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.Reporte
{
    public class ReporteFinancieroActividadHeaderViewModel
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
        public int? idCategoriaPresupuestal { get; set; }
        public string categoriaPresupuestalDescripcion { get; set; }
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
    }

    // ⚠️ IMPORTANTE: Propiedades de montos en MAYÚSCULAS
    public class ReporteFinancieroJerarquiaViewModel
    {
        public int ordenNivel { get; set; }
        public string nivel { get; set; }
        public int? idTarea { get; set; }
        public string codigoTarea { get; set; }
        public string descripcionTarea { get; set; }
        public int? idFuente { get; set; }
        public string fuenteFinanciamiento { get; set; }
        public int? idClasificadorTarea { get; set; }
        public string clasificadorTareaDescripcion { get; set; }
        public string tipoDetalle { get; set; }
        public string idDetalle { get; set; }
        public int? idClasificadorDetalle { get; set; }
        public string clasificadorDetalleDescripcion { get; set; }

        // Montos en MAYÚSCULAS
        public decimal MONTO_ENERO { get; set; }
        public decimal MONTO_FEBRERO { get; set; }
        public decimal MONTO_MARZO { get; set; }
        public decimal MONTO_ABRIL { get; set; }
        public decimal MONTO_MAYO { get; set; }
        public decimal MONTO_JUNIO { get; set; }
        public decimal MONTO_JULIO { get; set; }
        public decimal MONTO_AGOSTO { get; set; }
        public decimal MONTO_SETIEMBRE { get; set; }
        public decimal MONTO_OCTUBRE { get; set; }
        public decimal MONTO_NOVIEMBRE { get; set; }
        public decimal MONTO_DICIEMBRE { get; set; }
        public decimal MONTO_TOTAL { get; set; }
    }

    public class ReporteFinancieroTotalGeneralViewModel
    {
        public int idProgramacionActividad { get; set; }
        public decimal montoEnero { get; set; }
        public decimal montoFebrero { get; set; }
        public decimal montoMarzo { get; set; }
        public decimal montoAbril { get; set; }
        public decimal montoMayo { get; set; }
        public decimal montoJunio { get; set; }
        public decimal montoJulio { get; set; }
        public decimal montoAgosto { get; set; }
        public decimal montoSetiembre { get; set; }
        public decimal montoOctubre { get; set; }
        public decimal montoNoviembre { get; set; }
        public decimal montoDiciembre { get; set; }
        public decimal montoTotal { get; set; }
    }

    public class ObtenerReporteFinancieroResponseViewModel
    {
        public ReporteFinancieroActividadHeaderViewModel header { get; set; }
        public IEnumerable<ReporteFinancieroJerarquiaViewModel> jerarquia { get; set; }
        public ReporteFinancieroTotalGeneralViewModel totalGeneral { get; set; }
    }
}