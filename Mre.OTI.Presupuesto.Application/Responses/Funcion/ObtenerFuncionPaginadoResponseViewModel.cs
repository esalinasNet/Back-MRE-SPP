using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Persona;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.Funcion
{
    public class ObtenerFuncionPaginadoResponseViewModel : IMapFrom<ObtenerFuncionPaginadoResponseDTO>
    {
        public int idFuncion { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }
        public string funcion { get; set; }
        public string descripcion { get; set; }
        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }
        public int activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerFuncionPaginadoResponseDTO, ObtenerFuncionPaginadoResponseViewModel>();
        }
    }

    public class dtFuncionPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerFuncionPaginadoResponseViewModel> data { get; set; }
    }
}
