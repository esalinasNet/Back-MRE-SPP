using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas.Queries
{    
    public class ObtenerPlanillasPaginadoViewModel : IRequest<dtPlanillasPaginadoResponseViewModel>
    {        
        public int anio { get; set; }

        public string nroDocumento { get; set; }
        public string apellidosNombres { get; set; }
                
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
