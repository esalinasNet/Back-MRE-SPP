using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.ObjetivosInstitucionales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Queries
{
    public class ObtenerObjetivosInstitucionalesPaginadoViewModel : IRequest<dtObjetivosPaginadoInstitucionalesResponseViewModel>
    {
        //public int idObjetivos { get; set; }
        //public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoObjetivos { get; set; }
        public string descripcionObjetivos { get; set; }
        public string codigoAcciones { get; set; }
        //public string descripcionAcciones { get; set; }
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
