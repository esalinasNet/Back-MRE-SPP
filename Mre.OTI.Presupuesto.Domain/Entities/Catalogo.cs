using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Catalogo : Auditoria
    {

        public int ID_CATALOGO { get; set; }
        public int CODIGO_CATALOGO { get; set; }
        public string DESCRIPCION_CATALOGO { get; set; }

        public bool MANTENIBLE_POR_USUARIO { get; set; }

        public bool REPLICABLE { get; set; }

        public bool ACTIVO { get; set; }

        public int registro { get; set; }

        public int totalRegistro { get; set; }

    }
}
