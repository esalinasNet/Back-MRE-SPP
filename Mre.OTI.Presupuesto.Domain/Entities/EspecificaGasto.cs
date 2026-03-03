using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class EspecificaGasto : Auditoria
    {
        public int ID_CLASIFICADOR { get; set; }

        public int ID_ANIO { get; set; }

        public string CLASIFICADOR { get; set; }

        public string DESCRIPCION { get; set; }

        public string DESCRIPCION_DETALLADA { get; set; }

        public int ID_ESTADO { get; set; }

        public bool? ACTIVO { get; set; }

        public int ID_CATEGORIA_GASTO { get; set; }

        public string TIPO_CLASIFICADOR { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
