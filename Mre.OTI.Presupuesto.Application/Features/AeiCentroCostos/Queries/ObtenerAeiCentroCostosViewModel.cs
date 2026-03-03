using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries
{
    public class ObtenerAeiCentroCostosViewModel : IRequest<IEnumerable<ObtenerAeiCentroCostosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
        public int idAcciones { get; set; }
        //public int idAeiCostos { get; set; }
        //public int idCentroCostos { get; set; }

        //public bool? activo { get; set; }
    }
}
