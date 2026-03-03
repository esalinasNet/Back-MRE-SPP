using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerProgramacionAccionesViewModel : IRequest<ObtenerProgramacionAccionesResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idProgramacionAcciones { get; set; }
    }
}
