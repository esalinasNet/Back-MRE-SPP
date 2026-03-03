using System;

namespace Mre.OTI.Presupuesto.Domain.Base
{
    public class Auditoria
    {
        public bool activo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
