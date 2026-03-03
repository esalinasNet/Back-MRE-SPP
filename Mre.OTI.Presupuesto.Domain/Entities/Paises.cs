using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class Paises : Auditoria
    {
        public int ID_PAISES { get; set; }
        public string CODIGO { get; set; }
        public string NOMBRE_PAIS { get; set; }
        public string CONTINENTE { get; set; }
        public int ID_ESTADO { get; set; }
        public bool ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
