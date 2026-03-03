using Mre.OTI.Presupuesto.Application.Responses.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Seguridad.Queries
{
    public class ObtenerAutorizacionViewModel: IRequest<ObtenerAutorizacionResponseViewModel>
    {
        public int IdSistema { get; set; }
        public int IdOpcion { get; set; }
        public int IdPerfil { get; set; }
        public string Accion { get; set; }
    }
}
