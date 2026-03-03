using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.CategoriaPresupuestal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries
{
    public class ObtenerListadoCategoriaPresupuestalViewModel : IRequest<IEnumerable<ObtenerListadoCategoriaPresupuestalResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
    }
}
