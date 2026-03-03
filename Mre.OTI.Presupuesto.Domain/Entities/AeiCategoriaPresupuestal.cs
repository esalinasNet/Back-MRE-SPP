using Mre.OTI.Presupuesto.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class AeiCategoriaPresupuestal : Auditoria
    {
        public int ID_AEI_PRESUPUESTAL { get; set; }
        public int ID_ANIO { get; set; }
        public int ID_PRESUPUESTAL { get; set; }
        public int ID_ACCIONES { get; set; }        

        public int registro { get; set; }
        public int totalRegistro { get; set; }
    }
}
