using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class ViaticosDetalle : Auditoria
    {
        public int ID_PROGRAMACION_VIATICOS_DETALLE { get; set; }
        public int ID_PROGRAMACION_VIATICOS { get; set; }
        public int ID_CLASIFICADOR { get; set; }
        public string NOMBRE_CLASIFICADOR { get; set; }
        public string DENOMINACION_RECURSO { get; set; }
        public decimal MONTO { get; set; }
        public int CANTIDAD_PERSONAS { get; set; }
        public int DIAS { get; set; }
        public int MES { get; set; }

        public bool? ACTIVO { get; set; }
    }
}