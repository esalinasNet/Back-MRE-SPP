using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries
{
    public class ObtenerTipoDeCambioPaginadoViewModel : IRequest<dtTipoDeCambioPaginadoResponseViewModel>
    {

        public int idMoneda { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string codigoIso { get; set; }
        public string nombre { get; set; }
        public decimal valor { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool activo { get; set; }
        public int draw { get; set; }

        public string usuarioConsulta { get; set; }
        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }

    }
    
}
