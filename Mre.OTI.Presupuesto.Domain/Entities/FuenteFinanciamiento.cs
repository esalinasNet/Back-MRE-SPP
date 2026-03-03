using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class FuenteFinanciamiento : Auditoria
    {
        public int ID_FUENTE { get; set; }
        public int ID_ANIO { get; set; }
        public string FUENTE { get; set; }
        public string CODIGO_FUENTE { get; set; }
        public string DESCRIPCION_FUENTE { get; set; }        
        public string DESCRIPCION_RUBRO { get; set; }        
        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
