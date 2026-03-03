using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Componente.Queries
{
    public class ObtenerComponentePaginadoViewModel : IRequest<dtComponentePaginadoResponseViewModel>
    {
        //public int idComponente { get; set; }
        //public int idAnio { get; set; }
        public int anio { get; set; }
        public string componente { get; set; }
        public string tipoComponente { get; set; }
        public string descripcion { get; set; }
        //public int idEstado { get; set; }
        //public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }

    }
}
