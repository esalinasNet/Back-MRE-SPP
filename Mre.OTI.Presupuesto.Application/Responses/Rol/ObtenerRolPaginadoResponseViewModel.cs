using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.Mapper;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.Rol
{
    public class ObtenerRolPaginadoResponseViewModel : IMapFrom<ObtenerRolPaginadoResponseDTO>
    {
        public string nombreSistema { get; set; }
        public int idRol { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int activo { get; set; }
        public int registro { get; set; }

        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerRolPaginadoResponseDTO, ObtenerRolPaginadoResponseViewModel>();
        }
    }

    public class dtRolPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerRolPaginadoResponseViewModel> data { get; set; }
    }
}
