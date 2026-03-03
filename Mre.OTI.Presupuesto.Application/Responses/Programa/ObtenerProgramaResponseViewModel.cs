using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Programa;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Programa
{
    public class ObtenerProgramaResponseViewModel : IMapFrom<ObtenerProgramaResponseDTO>
    {
        public int idPrograma { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string programa { get; set; }
        public string descripcion { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public int activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerProgramaResponseDTO, ObtenerProgramaResponseViewModel>();
        }
    }
}
