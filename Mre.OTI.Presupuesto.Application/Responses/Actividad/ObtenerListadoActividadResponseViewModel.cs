using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Actividad
{
    public class ObtenerListadoActividadResponseViewModel
    {
        public int idActividad { get; set; }
        public int anio { get; set; }
        public string actividad { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
    }
}
