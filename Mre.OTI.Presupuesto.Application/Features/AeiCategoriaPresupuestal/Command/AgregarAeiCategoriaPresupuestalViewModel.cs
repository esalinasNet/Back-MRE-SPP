using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Command
{
    public class AgregarAeiCategoriaPresupuestalViewModel : IRequest<CommandResponseViewModel>
    {
        public int idAnio { get; set; }
        public int idPresupuestal { get; set; }
        public int idAcciones { get; set; }        

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
