using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.UbigeoExterior;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior
{
    public class ObtenerUbigeoExteriorResponseViewModel : IMapFrom<ObtenerUbigeoExteriorResponseDTO>
    {
        public int idUbigeoExterior { get; set; }
        public string item { get; set; }
        public string zone { get; set; }
        public string region { get; set; }
        public string pais { get; set; }
        public string oseRes { get; set; }
        public string ose { get; set; }
        public string tipoMision { get; set; }
        public string nombreOse { get; set; }
        public string moneda { get; set; }
        public string mon { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public bool? activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerUbigeoExteriorResponseDTO, ObtenerUbigeoExteriorResponseViewModel>();
        }
    }
}
