using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries
{
    public class ObtenerEspecificaGastoPaginadoViewModel : IRequest<dtEspecificaGastoPaginadoResponseViewModel>
    {
        public int idClasificador {  get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string clasificador { get; set; }
        public string descripcion { get; set; }
        public string descripcion_detallada { get; set; }
        public int idEstado {  get; set; }
        public string estado {  get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
