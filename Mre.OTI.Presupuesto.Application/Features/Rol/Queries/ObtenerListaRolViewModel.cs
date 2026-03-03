using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Rol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Queries
{
    public class ObtenerListaRolViewModel : IRequest<IEnumerable<ObtenerListaRolResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }        
    }
}
