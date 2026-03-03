using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerUbigeoPaginadoViewModel : IRequest<dtUbigeoPaginadoResponseViewModel>
    {        
        public string pais { get; set; }
        public string ubigeo { get; set; }
        public string codigo_departamento { get; set; }
        public string departamento { get; set; }
        public string codigo_provincia { get; set; }
        public string provincia { get; set; }
        public string codigo_distrito { get; set; }
        public string distrito { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
