using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries
{
    public class ObtenerProgramacionActividadPaginadoViewModel : IRequest<dtProgramacionActividadPaginadoResponseViewModel>
    {
        public int anio { get; set; }

        public string codigoProgramacion { get; set; }
        public int? idCentroCostos { get; set; }
        public string denominacion { get; set; }
        public string descripcion { get; set; }
        public string observacion { get; set; }

        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
