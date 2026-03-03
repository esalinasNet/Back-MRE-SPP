using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.SubPrograma;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Queries
{
    public class ObtenerSubProgramaViewModel : IRequest<ObtenerSubProgramaResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idSubPrograma { get; set; }
    }
}
