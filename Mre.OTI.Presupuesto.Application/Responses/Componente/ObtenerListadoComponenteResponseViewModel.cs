using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Componente
{
    public class ObtenerListadoComponenteResponseViewModel
    {
        public int idComponente { get; set; }
        public int anio { get; set; }
        public string componente { get; set; }
        public string tipoComponente { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
    }
}
