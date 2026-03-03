using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Queries
{    
    public class ObtenerAprobacionesCostosPaginadoViewModel : IRequest<dtAprobacionesCostosPaginadoResponseViewModel>
    {
        public int anio { get; set; }

        public string centroCostos { get; set; }
        public string descripcionCostos { get; set; }

        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
