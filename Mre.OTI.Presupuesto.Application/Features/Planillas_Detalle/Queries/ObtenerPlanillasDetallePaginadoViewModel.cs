using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Planillas_Detalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Queries
{
    public class ObtenerPlanillasDetallePaginadoViewModel : IRequest<dtPlanillasDetallePaginadoResponseViewModel>
    {
        public int idPlanillas { get; set; }

        public bool? activo { get; set; }

        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
