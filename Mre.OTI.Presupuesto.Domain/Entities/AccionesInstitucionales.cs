using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class AccionesInstitucionales : Auditoria
    {
        public int ID_ACCIONES { get; set; }
        public int ID_ANIO { get; set; }

        public string CODIGO_ACCONES { get; set; }
        public string DESCRIPCION_ACCIONES { get; set; }

        public string CODIGO_OBJETIVOS { get; set; }
        public string DESCRIPCION_OBJETIVOS { get; set; }

        public int NRO_CENTRO_COSTOS { get; set; }

        public List<int> ID_CENTRO_COSTOS { get; set; }

        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
