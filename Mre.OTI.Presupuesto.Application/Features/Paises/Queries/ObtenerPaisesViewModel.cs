using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Paises;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Paises.Queries
{
    public class ObtenerPaisesViewModel : IRequest<ObtenerPaisesResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idPaises { get; set; }        
    }
}
