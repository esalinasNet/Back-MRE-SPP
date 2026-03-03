using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio
{
    public class ObtenerTipoDeCambioPaginadoResponseViewModel : IMapFrom<ObtenerTipoDeCambioPaginadoResponseDTO>
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

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerTipoDeCambioPaginadoResponseDTO, ObtenerTipoDeCambioPaginadoResponseViewModel>();
        }

    }

    public class dtTipoDeCambioPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerTipoDeCambioPaginadoResponseViewModel> data { get; set; }
    }
}
