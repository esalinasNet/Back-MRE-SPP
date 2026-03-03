using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.CategoriaPresupuestal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries
{
    public class ObtenerCategoriaPresupuestalViewModel : IRequest<ObtenerCategoriaPresupuestalResponseViewModel>
    {
        public string usuarioConsulta { get; set; }
        public int idPresupuestal { get; set; }
    }
}
