using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.AccionesInstitucionales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Queries
{
    public class ObtenerAccionesInstitucionalesPaginadoViewModel : IRequest<dtAccionesInstitucionalesPaginadoResponseViewModel>
    {
        //public int idAcciones { get; set; }
        //public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }

        public string codigoObjetivos { get; set; }
        //public string descripcionObjetivos { get; set; }

        //public int idEstado { get; set; }
        //public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
