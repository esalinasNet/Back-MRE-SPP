using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class CajaChica : Auditoria
    {
        public int ID_PROGRAMACION_CAJA_CHICA { get; set; }
        public int ID_PROGRAMACION_RECURSO { get; set; }
        public int ID_PROGRAMACION_TAREAS { get; set; }
        public int ID_ANIO { get; set; }
        public int ID_ACTIVIDAD_OPERATIVA { get; set; }
        public int ID_TAREA { get; set; }
        public int? ID_UNIDAD_MEDIDA { get; set; }
        public bool? REPRESENTATIVA { get; set; }
        public int? ID_FUENTE_FINANCIAMIENTO { get; set; }
        public int? ID_UBIGEO { get; set; }
        public int? TIPO_UBIGEO { get; set; }

        // Montos mensuales
        public decimal? MONTO_ENERO { get; set; }
        public decimal? MONTO_FEBRERO { get; set; }
        public decimal? MONTO_MARZO { get; set; }
        public decimal? MONTO_ABRIL { get; set; }
        public decimal? MONTO_MAYO { get; set; }
        public decimal? MONTO_JUNIO { get; set; }
        public decimal? MONTO_JULIO { get; set; }
        public decimal? MONTO_AGOSTO { get; set; }
        public decimal? MONTO_SETIEMBRE { get; set; }
        public decimal? MONTO_OCTUBRE { get; set; }
        public decimal? MONTO_NOVIEMBRE { get; set; }
        public decimal? MONTO_DICIEMBRE { get; set; }

        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }
    }
}