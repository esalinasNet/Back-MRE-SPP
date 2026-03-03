using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Queries
{
    public class ObtenerDivisionFuncionalViewModel : IRequest<ObtenerDivisionFuncionalResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idDivisionFuncional { get; set; }
    }
}
