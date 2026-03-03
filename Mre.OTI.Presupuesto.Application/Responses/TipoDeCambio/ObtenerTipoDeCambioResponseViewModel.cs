using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio
{
    public class ObtenerTipoDeCambioResponseViewModel : IMapFrom<ObtenerTipoDeCambioResponseDTO>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerTipoDeCambioResponseDTO, ObtenerTipoDeCambioResponseViewModel>();
        }
    }
}
