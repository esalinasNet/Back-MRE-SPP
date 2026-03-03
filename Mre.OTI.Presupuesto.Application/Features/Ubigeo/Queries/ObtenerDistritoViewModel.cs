using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerDistritoViewModel : IRequest<ObtenerDistritoResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public string ubigeo {  get; set; } 
    }
}
