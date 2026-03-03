using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Ubigeo
{
    public class ObtenerListadoUbigeoResponseViewModel
    {
        public int idUbigeo { get; set; }
        public string pais { get; set; }
        public string ubigeo { get; set; }
        public string departamento { get; set; }
        //public string provincia { get; set; }
        //public string distrito { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
    }
}
