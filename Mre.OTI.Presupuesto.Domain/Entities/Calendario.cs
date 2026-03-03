using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Calendario: Auditoria
    {
        public int ID_PERIODO { get; set; }
        public int ID_ANIO { get; set; }        
        public int ID_MES { get; set; }
        public int ID_CENTRO_COSTOS { get; set; }        
        public DateTime? FECHAINICIO { get; set; }
        public DateTime? FECHAFIN { get; set; }
        public int ID_ESTADO { get; set; }        
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
