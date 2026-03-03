using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Sistema.Queries
{
    public class ObtenerSistemaPaginadoViewModel : IRequest<dtSistemaPaginadoResponseViewModel>
    {   
     
        public string nombre { get; set; }
        public string descripcion { get; set; }                
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }

    }
}