using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class FasesPoi : Auditoria
    {
        public int ID_FASES_POI { get; set; }
        public int ID_ANIO { get; set; }

        public string CODIGO_FASES { get; set; }
        public string DESCRIPCION_FASES { get; set; }

        public int ANIO_INICIAL { get; set; }
        public int ANIO_FINAL { get; set; }

        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
