using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Ubigeo
{
    public class ObtenerUbigeoResponseViewModel : IMapFrom<ObtenerUbigeoResponseDTO>
    {
        public int idUbigeo { get; set; }
        public string pais { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string descripcion { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerFuncionResponseDTO, ObtenerFuncionResponseViewModel>();
        }
    }
}
