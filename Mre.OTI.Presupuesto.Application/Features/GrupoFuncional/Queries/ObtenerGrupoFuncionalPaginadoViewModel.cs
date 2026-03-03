using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries
{
    public class ObtenerGrupoFuncionalPaginadoViewModel : IRequest<dtGrupoFuncionalPaginadoResponseViewModel>
    {
        //public int idGrupoFuncional { get; set; }
        //public int idAnio { get; set; }
        public int anio { get; set; }

        public string grupoFuncional { get; set; }
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
