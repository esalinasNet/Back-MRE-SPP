using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.DTO.GrupoFuncional;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional
{
    public class ObtenerGrupoFuncionalPaginadoResponseViewModel : IMapFrom<ObtenerGrupoFuncionalPaginadoResponseDTO>
    {
        public int idGrupoFuncional { get; set; }
        public int idAnio { get; set; }
        public int anio { get; set; }

        public string grupoFuncional { get; set; }
        public string descripcion { get; set; }

        public int idEstado { get; set; }
        public int estado { get; set; }
        public string estadoDescripcion { get; set; }

        public bool? activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerGrupoFuncionalPaginadoResponseDTO, ObtenerGrupoFuncionalPaginadoResponseViewModel>();
        }
    }

    public class dtGrupoFuncionalPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerGrupoFuncionalPaginadoResponseViewModel> data { get; set; }
    }
}
