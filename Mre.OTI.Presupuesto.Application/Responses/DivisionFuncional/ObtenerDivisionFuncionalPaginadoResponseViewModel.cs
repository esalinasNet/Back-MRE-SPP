using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional
{
    public class ObtenerDivisionFuncionalPaginadoResponseViewModel : IMapFrom<ObtenerDivisionFuncionalPaginadoResponseDTO>
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

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerDivisionFuncionalPaginadoResponseDTO, ObtenerDivisionFuncionalPaginadoResponseViewModel>();
        }
    }

    public class dtDivisionFuncionalPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerDivisionFuncionalPaginadoResponseViewModel> data { get; set; }
    }
}
