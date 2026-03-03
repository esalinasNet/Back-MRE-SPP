using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries
{
    public class ObtenerProgramacionClasificadorViewModel : IRequest<ObtenerProgramacionClasificadorResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idProgramacionClasificador { get; set; }
    }
}
