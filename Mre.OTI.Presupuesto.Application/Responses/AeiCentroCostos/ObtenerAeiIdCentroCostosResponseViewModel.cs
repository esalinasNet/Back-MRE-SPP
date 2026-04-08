using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos
{
    public class ObtenerAeiIdCentroCostosResponseViewModel
    {
        public int idAeiCostos { get; set; }
        public int idAnio { get; set; }
        public int idAcciones { get; set; }
        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }

        public int idObjetivos { get; set; }
        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }
        public int idCentroCostos { get; set; }

        public bool? activo { get; set; }

    }
}
