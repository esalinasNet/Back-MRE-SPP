using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.BienesServicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.BienesServicios.Queries
{
    public class ObtenerListadoGrupoBienesServiciosViewModel : IRequest<IEnumerable<ObtenerListadoGrupoBienesServiciosResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
        public string tipoBien { get; set; }
    }
}
