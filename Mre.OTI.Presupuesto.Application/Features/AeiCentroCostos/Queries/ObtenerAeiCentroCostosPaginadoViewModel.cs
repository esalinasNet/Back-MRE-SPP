using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries
{
    public class ObtenerAeiCentroCostosPaginadoViewModel : IRequest<dtAeiCentroCostosPaginadoResponseViewModel>
    {
        //public int idAeiCostos { get; set; }
        public int idAnio { get; set; }
        //public int anio { get; set; }

        public int idAcciones { get; set; }
        public string codigoAcciones { get; set; }
        public string descripcionAcciones { get; set; }

        //public int idCentroCostos { get; set; }
        //public string centroCostos { get; set; }
        //public string descripcionCostos { get; set; }

        //public int idEstado { get; set; }
        //public int estado { get; set; }
        //public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
