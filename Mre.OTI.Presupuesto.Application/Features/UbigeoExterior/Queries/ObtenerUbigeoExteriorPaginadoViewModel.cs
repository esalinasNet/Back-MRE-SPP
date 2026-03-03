using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    public class ObtenerUbigeoExteriorPaginadoViewModel : IRequest<dtUbigeoExteriorPaginadoResponseViewModel>
    {   
        public string item { get; set; }
        public string zone { get; set; }
        public string region { get; set; }
        public string pais { get; set; }
        public string oseRes { get; set; }
        public string ose { get; set; }
        public string tipoMision { get; set; }
        public string nombreOse { get; set; }
        public string moneda { get; set; }
        public string mon { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
