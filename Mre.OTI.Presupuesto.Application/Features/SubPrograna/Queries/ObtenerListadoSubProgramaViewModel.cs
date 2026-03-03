using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.SubPrograma;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Queries
{
    public class ObtenerListadoSubProgramaViewModel : IRequest<IEnumerable<ObtenerListadoSubProgramaResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
    }
}
