using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.DTO.Reporte
{
    // Request
    public class ObtenerReporteFinancieroRequestDTO
    {
        public int idProgramacionActividad { get; set; }
    }

    // RS1: Header de Actividad
    public class ReporteFinancieroActividadHeaderDTO
    {
        public int idProgramacionActividad { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        // Centro de costos
        public int? idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string centroCostosDescripcion { get; set; }
        public string centroCostosPadre { get; set; }
        public string centroCostosPadreDescripcion { get; set; }

        // Identificación actividad
        public string codigoProgramacionActividad { get; set; }
        public string denominacionActividad { get; set; }
        public string descripcionActividad { get; set; }

        // Plan estratégico institucional
        public int? idObjetivosInstitucionales { get; set; }
        public string objetivosInstitucionalesDescripcion { get; set; }
        public int? idAccionesInstitucionales { get; set; }
        public string accionesInstitucionalesDescripcion { get; set; }

        // Categoría presupuestal
        public int? idCategoriaPresupuestal { get; set; }
        public string categoriaPresupuestalDescripcion { get; set; }

        // Estructura funcional programática
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

    // RS2: Jerarquía Financiera
    // ⚠️ IMPORTANTE: Propiedades en MAYÚSCULAS para mapear correctamente con Dapper
    public class ReporteFinancieroJerarquiaDTO
    {
        public int ordenNivel { get; set; }
        public string nivel { get; set; }

        // Tarea
        public int? idTarea { get; set; }
        public string codigoTarea { get; set; }
        public string descripcionTarea { get; set; }

        // Fuente
        public int? idFuente { get; set; }
        public string fuenteFinanciamiento { get; set; }

        // Clasificador de tarea
        public int? idClasificadorTarea { get; set; }
        public string clasificadorTareaDescripcion { get; set; }

        // Detalle
        public string tipoDetalle { get; set; }
        public string idDetalle { get; set; }
        public int? idClasificadorDetalle { get; set; }
        public string clasificadorDetalleDescripcion { get; set; }

        // ⚠️ Montos en MAYÚSCULAS (como vienen del SP)
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

    // RS3: Total General
    // Montos en camelCase (como vienen del SP para totalGeneral)
    public class ReporteFinancieroTotalGeneralDTO
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

    // Response que encapsula los 3 RS
    public class ObtenerReporteFinancieroResponseDTO
    {
        public ReporteFinancieroActividadHeaderDTO header { get; set; }
        public IEnumerable<ReporteFinancieroJerarquiaDTO> jerarquia { get; set; }
        public ReporteFinancieroTotalGeneralDTO totalGeneral { get; set; }
    }
}