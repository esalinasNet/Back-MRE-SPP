using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Command
{
    public class AgregarObjetivosInstitucionalesViewModel : IRequest<CommandResponseViewModel>
    {
        public int idObjetivos { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }
        public int idAcciones { get; set; }
        //public string codigoAcciones { get; set; }
        //public string descripcionAcciones { get; set; }
        public int idEstado { get; set; }

        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
