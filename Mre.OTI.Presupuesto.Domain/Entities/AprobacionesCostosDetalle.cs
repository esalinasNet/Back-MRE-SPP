using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class AprobacionesCostosDetalle : Auditoria
    {
        public int ID_APROBACIONES_DETALLE { get; set; }
        public int ID_APROBACIONES { get; set; }
        public int ID_PERSONA { get; set; }
        //public int ID_CENTRO_COSTOS { get; set; }

        public string PUESTO_TRABAJO { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }

        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
