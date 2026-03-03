using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Sistema : Auditoria
    {
        public int ID_SISTEMA { get; set; }        
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }        
        public bool ACTIVO { get; set; }
        public string CODIGO_SISTEMA { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
