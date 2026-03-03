using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.AeiCategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Queries
{
    public class ObtenerAeiCategoriaPresupuestalViewModel : IRequest<IEnumerable<ObtenerAeiCategoriaPresupuestalResponseViewModel>>
    {
        public string usuarioConsulta { get; set; }
        public int idAnio { get; set; }
        public int idPresupuestal { get; set; }
    }
}
