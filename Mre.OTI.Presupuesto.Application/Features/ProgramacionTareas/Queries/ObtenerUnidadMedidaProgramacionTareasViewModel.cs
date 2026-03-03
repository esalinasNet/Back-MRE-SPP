using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries
{
    public class ObtenerUnidadMedidaProgramacionTareasViewModel : IRequest<ObtenerUidadMedidaProgramacionTareasResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idProgramacionTareas { get; set; }
        public int idUnidadMedida { get; set; }
    }
}