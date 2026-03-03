using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries
{
    public class ObtenerProgramacionClasificadorPaginadoViewModel : IRequest<dtProgramacionClasificadorPaginadoResponseViewModel>
    {
        public int anio { get; set; }

        public int idProgramacionActividad { get; set; }
        public string codigoClasificador { get; set; }
        public string descripcionClasificador { get; set; }

        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
