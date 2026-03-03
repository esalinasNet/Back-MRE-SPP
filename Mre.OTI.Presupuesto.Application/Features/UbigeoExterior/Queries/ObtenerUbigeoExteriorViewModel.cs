using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    public class ObtenerUbigeoExteriorViewModel : IRequest<ObtenerUbigeoExteriorResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idUbigeoExterior { get; set; }
    }
}
