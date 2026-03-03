using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerUnidadMedidaProgramacionAccionesViewModel : IRequest<ObtenerUidadMedidaProgramacionAccionesResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idProgramacionTareas { get; set; }
        public int idUnidadMedida { get; set; }
    }
}
