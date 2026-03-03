using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class TipoDeCambio : Auditoria
    {
        public int ID_MONEDA { get; set; }
        public int ID_ANIO { get; set; }
        public string CODIGO_ISO { get; set; }
        public string NOMBRE { get; set; }
        public decimal VALOR { get; set; }
        public int ID_ESTADO { get; set; }        
        public bool ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
