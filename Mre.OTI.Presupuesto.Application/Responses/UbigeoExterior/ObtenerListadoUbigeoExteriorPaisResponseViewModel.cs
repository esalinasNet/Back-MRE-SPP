using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior
{
    public class ObtenerListadoUbigeoExteriorPaisResponseViewModel 
    {
        public string codigoPais { get; set; }        
        public string pais { get; set; }
    }
}
