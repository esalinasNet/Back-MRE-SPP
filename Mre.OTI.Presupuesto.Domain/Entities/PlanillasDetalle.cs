using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class PlanillasDetalle : Auditoria
    {
        public int ID_PLANILLA_DETALLE { get; set; }

        public int ID_PLANILLA { get; set; }

        public int ID_ESPECIFICA { get; set; }

        public DateTime PERIODO { get; set; }

        public decimal IMPORTE { get; set; }

        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
