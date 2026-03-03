using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Catalogo;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries
{
    public class ObtenerCatalogoPaginadoViewModel : IRequest<dtCatalogoPaginadoResponseViewModel>
    {
        //public string usuarioConsulta { get; set; }
        //public int idCatalogo { get; set; }
        //public string descripcionCatalogo { get; set; }

        //public int draw { get; set; }

        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }

 
}
