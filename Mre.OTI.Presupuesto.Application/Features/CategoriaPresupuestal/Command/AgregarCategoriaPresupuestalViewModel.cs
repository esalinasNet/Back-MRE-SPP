using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Command
{
    public class AgregarCategoriaPresupuestalViewModel : IRequest<CommandResponseViewModel>
    {
        public int idPresupuestal { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoPresupuestal { get; set; }
        public string descripcionPresupuestal { get; set; }

        //public int idAcciones { get; set; }
        //public string codigoAcciones { get; set; }
        //public string descripcionAcciones { get; set; }

        public List<int> idAcciones { get; set; }
        public int nroCodigoAcciones { get; set; }

        public int idEstado { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
