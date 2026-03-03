using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Ubigeo
{
    public class ObtenerDistritoResponseViewModel : IMapFrom<ObtenerDistritoResponseDTO>
    {
        public int idUbigeo { get; set; }
        public string pais { get; set; }
        public string ubigeo { get; set; }
        public string codigo_departamento { get; set; }
        public string departamento { get; set; }
        public string codigo_provincia { get; set; }
        public string provincia { get; set; }
        public string codigo_distrito { get; set; }
        public string distrito { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerDistritoResponseDTO, ObtenerDistritoResponseViewModel>();
        }
    }
}
