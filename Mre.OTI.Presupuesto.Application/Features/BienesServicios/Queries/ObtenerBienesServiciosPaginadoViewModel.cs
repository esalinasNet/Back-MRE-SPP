using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.BienesServicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.BienesServicios.Queries
{
    public class ObtenerBienesServiciosPaginadoViewModel : IRequest<dtBienesServiciosPaginadoResponseViewModel>
    {
        //public int idBienesServicios { get; set; }
        //public int idAnio { get; set; }
        public int anio { get; set; }

        public string codigoBien { get; set; }
        public string nombreBien { get; set; }
        public string tipoItems { get; set; }

        //public int idUinidadMedida { get; set; }
        //public string uinidadMedida { get; set; }

        //public decimal precio { get; set; }

        //public int idClasificador { get; set; }
        //public string clasificadorGasto { get; set; }
        //public string denominacionEegg { get; set; }

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
