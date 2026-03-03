using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Finalidad;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Finalidad
{
    public class ObtenerFinalidadResponseViewModel : IMapFrom<ObtenerFinalidadResponseDTO>
    {
        public int idFinalidad { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string finalidad { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerFinalidadResponseDTO, ObtenerFinalidadResponseViewModel>();
        }
    }
}

