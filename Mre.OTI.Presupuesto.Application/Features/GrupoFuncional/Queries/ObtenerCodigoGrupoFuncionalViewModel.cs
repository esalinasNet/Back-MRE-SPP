using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries
{
    public class ObtenerCodigoGrupoFuncionalViewModel : IRequest<ObtenerCodigoGrupoFuncionalResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int anio { get; set; }
        public string grupoFuncional { get; set; }
    }
}
