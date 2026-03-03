using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.AeiCategoriaPresupuestal
{
    public class ObtenerAeiCategoriaPresupuestalResponseViewModel
    {
        public int idAeiPresupuestal { get; set; }
        public int idAnio { get; set; }
        public int idPresupuestal { get; set; }
        public int idAcciones { get; set; }        

        public bool? activo { get; set; }
    }
}
