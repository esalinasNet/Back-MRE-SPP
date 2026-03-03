using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos_Detalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Queries
{
    public class ObtenerAprobacionesCostosDetallePaginadoViewModel : IRequest<dtAprobacionesCostosDetallePaginadoResponseViewModel>
    {
        public int idAprobaciones { get; set; }

        public bool? activo { get; set; }

        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
