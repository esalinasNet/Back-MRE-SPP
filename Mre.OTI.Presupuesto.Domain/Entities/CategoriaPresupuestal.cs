using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class CategoriaPresupuestal : Auditoria
    {
        public int ID_PRESUPUESTAL { get; set; }
        public int ID_ANIO { get; set; }

        public string CODIGO_PRESUPUESTAL { get; set; }
        public string DESCRIPCION_PRESUPUESTAL { get; set; }

        //public int ID_ACCIONES { get; set; }
        public List<int> ID_ACCIONES { get; set; }

        public int NRO_CODIGO_ACCIONES { get; set; }

        public int ID_ESTADO { get; set; }
        public bool? ACTIVO { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
