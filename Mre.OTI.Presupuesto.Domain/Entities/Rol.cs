using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Rol : Auditoria
    {
        public int ID_ROL { get; set; }
        public int CODIGO_ROL { get; set; }
        public int ID_SISTEMA { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
