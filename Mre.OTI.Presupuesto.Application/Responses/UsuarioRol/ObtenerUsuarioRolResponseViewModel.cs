using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.UsuarioRol;
using Mre.OTI.Presupuesto.Application.Mapper;

namespace Mre.OTI.Presupuesto.Application.Responses.UsuarioRol
{
    public class ObtenerUsuarioRolResponseViewModel : IMapFrom<ObtenerUsuarioRolResponseDTO>
    {
        public int idUsuarioRol { get; set; }
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public int idCentroCostos { get; set; }
        public int accesoPrivado { get; set; }
        public int activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerUsuarioRolResponseDTO, ObtenerUsuarioRolResponseViewModel>();
        }
    }
}
