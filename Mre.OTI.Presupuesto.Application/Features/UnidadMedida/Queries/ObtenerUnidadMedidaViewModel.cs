using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.UnidadMedida;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries
{
    public class ObtenerUnidadMedidaViewModel : IRequest<ObtenerUnidadMedidaResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idUnidadMedida { get; set; }
    }
}
