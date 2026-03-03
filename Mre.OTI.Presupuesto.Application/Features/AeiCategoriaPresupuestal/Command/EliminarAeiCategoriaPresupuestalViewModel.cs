using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Command
{
    public class EliminarAeiCategoriaPresupuestalViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAnio { get; set; }
        public int idPresupuestal { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }
    }
}
