using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerDepartamentoViewModel : IRequest<ObtenerDepartamentoResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        //public int idUbigeo { get; set; }
        public string ubigeo { get; set; }
    }
}
