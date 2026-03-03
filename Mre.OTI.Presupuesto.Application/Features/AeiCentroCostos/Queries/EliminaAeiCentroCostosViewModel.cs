using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries
{
    public class EliminaAeiCentroCostosViewModel : IRequest<EliminaAeiCentroCostosResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idAcciones { get; set; }
    }
}
