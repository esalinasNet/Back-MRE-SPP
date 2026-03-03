using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional
{
    public class ObtenerCodigoDivisionResponseViewModel : IMapFrom<ObtenerCodigoDivisionResponseDTO>
    {
        public int idDivisionFuncional { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string divisionFuncional { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerCodigoDivisionResponseDTO, ObtenerCodigoDivisionResponseViewModel>();
        }
    }
}
