using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.UsuarioRol;
using Mre.OTI.Presupuesto.Application.Mapper;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.UsuarioRol
{
    public class ObtenerUsuarioRolPaginadoResponseViewModel : IMapFrom<ObtenerUsuarioRolPaginadoResponseDTO>
    {
        public int idUsuarioRol { get; set; }
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string rol { get; set; }
        public string usuario { get; set; }
        public int idCentroCostos { get; set; }
        public int accesoPrivado { get; set; }

        public string nombreSistema { get; set; }
        public string nombreOSE { get; set; }

        public int activo { get; set; }

        public int registro { get; set; }
        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerUsuarioRolPaginadoResponseDTO, ObtenerUsuarioRolPaginadoResponseViewModel>();
        }
    }

    public class dtUsuarioRolPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerUsuarioRolPaginadoResponseViewModel> data { get; set; }
    }
}
