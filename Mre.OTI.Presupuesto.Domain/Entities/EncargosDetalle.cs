using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class EncargosDetalle : Auditoria
    {
        public int ID_PROGRAMACION_ENCARGOS_DETALLE { get; set; }
        public int ID_PROGRAMACION_ENCARGOS { get; set; }
        public int ID_CLASIFICADOR { get; set; }
        public string NOMBRE_CLASIFICADOR { get; set; }
        public string DENOMINACION_RECURSO { get; set; }
        public decimal MONTO { get; set; }  // AGREGADO
        public decimal VALOR { get; set; }
        public int MES { get; set; }

        public bool? ACTIVO { get; set; }
    }
}