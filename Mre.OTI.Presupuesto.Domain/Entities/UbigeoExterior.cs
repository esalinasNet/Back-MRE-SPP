using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class UbigeoExterior : Auditoria
    {
        public int ID_UBIGEO_EXTERIOR { get; set; }
        public string ITEM { get; set; }
        public string ZONE { get; set; }
        public string REGION { get; set; }
        public string PAIS { get; set; }
        public string OSE_RES { get; set; }
        public string OSE { get; set; }
        public string TIPO_MISION { get; set; }
        public string NOMBRE_OSE { get; set; }
        public string MONEDA { get; set; }
        public string MON { get; set; }
        public int ID_ESTADO { get; set; }
        public bool ACTIVO { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
