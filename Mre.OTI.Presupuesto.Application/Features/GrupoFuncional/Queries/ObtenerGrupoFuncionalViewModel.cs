using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries
{
    public class ObtenerGrupoFuncionalViewModel : IRequest<ObtenerGrupoFuncionalResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idGrupoFuncional { get; set; }
    }
}
