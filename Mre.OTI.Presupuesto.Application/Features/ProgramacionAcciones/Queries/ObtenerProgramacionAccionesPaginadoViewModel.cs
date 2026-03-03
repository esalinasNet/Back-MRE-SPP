using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerProgramacionAccionesPaginadoViewModel : IRequest<dtProgramacionAccionesPaginadoResponseViewModel>
    {
        public int anio { get; set; }

        public int idProgramacionActividad { get; set; }
        public int idProgramacionTareas { get; set; }
        public string codigoAcciones { get; set; }

        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
