using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class CentroCostos : Auditoria
    {
        public int ID_CENTRO_COSTOS { get; set; }
        public int ID_ANIO { get; set; }
        public int ID_EJECUTORA { get; set; }
        public string CENTRO_COSTOS { get; set; }
        public string DESCRIPCION { get; set; }
        public string CENTRO_COSTOS_PADRE { get; set; }
        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

    }
}
