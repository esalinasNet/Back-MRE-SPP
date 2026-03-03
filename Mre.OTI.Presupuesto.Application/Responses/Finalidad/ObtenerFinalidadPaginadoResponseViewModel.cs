using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Finalidad;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Finalidad
{
    public class ObtenerFinalidadPaginadoResponseViewModel : IMapFrom<ObtenerFinalidadPaginadoResponseDTO>
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

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerFinalidadPaginadoResponseDTO, ObtenerFinalidadPaginadoResponseViewModel>();
        }
    }

    public class dtFinalidadPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerFinalidadPaginadoResponseViewModel> data { get; set; }
    }
}
