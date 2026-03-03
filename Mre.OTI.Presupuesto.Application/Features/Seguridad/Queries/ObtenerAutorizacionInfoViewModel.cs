using Mre.OTI.Presupuesto.Application.Responses.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Seguridad.Queries
{
    public class ObtenerAutorizacionInfoViewModel: IRequest<ObtenerAutozacionInfoResponseViewModel>
    {
        public string IdSistema { get; set; }
        public string IdPerfil { get; set; }

    }
}
