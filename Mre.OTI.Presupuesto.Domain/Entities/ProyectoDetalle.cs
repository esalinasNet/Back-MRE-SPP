using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class ProyectoDetalle : Auditoria
    {
        public int ID_PROGRAMACION_PROYECTO_DETALLE { get; set; }
        public int ID_PROGRAMACION_PROYECTO { get; set; }
        public string CODIGO_ITEM { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal VALOR { get; set; }
        public int ID_UNIDAD_MEDIDA { get; set; }
        public int ID_CLASIFICADOR { get; set; }
        public string NOMBRE_CLASIFICADOR { get; set; }

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

        public bool? ACTIVO { get; set; }
    }
}