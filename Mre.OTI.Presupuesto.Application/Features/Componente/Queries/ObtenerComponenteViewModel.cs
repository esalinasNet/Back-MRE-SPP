using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Componente.Queries
{
    public class ObtenerComponenteViewModel : IRequest<ObtenerComponenteResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idComponente { get; set; }
    }
}
