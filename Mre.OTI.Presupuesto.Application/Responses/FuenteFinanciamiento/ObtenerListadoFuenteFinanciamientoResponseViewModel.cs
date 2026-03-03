using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.FuenteFinanciamiento
{
    public class ObtenerListadoFuenteFinanciamientoResponseViewModel
    {
        public int idFuente { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string fuente { get; set; }
        public string codigoFuente { get; set; }
        public string descripcionFuente { get; set; }
        public string descripcionRubro { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
