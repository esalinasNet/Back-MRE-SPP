using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries
{
    public class ObtenerTipoDeCambioViewModel : IRequest<ObtenerTipoDeCambioResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idMoneda { get; set; }        
    }
}
