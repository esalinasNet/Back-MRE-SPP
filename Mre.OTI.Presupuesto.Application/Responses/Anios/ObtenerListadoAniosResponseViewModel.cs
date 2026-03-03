using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Anios
{
    public class ObtenerListadoAniosResponseViewModel
    {
        public int idAnio { get; set; }
        public int anio { get; set; }        
        public string descripcion { get; set; }
        public int estado { get; set; }
    }
}
