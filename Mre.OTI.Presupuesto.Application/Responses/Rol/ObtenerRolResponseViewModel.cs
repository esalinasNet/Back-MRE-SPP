using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Rol;
using Mre.OTI.Presupuesto.Application.Mapper;

namespace Mre.OTI.Presupuesto.Application.Responses.Rol
{
    public class ObtenerRolResponseViewModel : IMapFrom<ObtenerRolResponseDTO>
    {

        public int idRol { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int codigoRol { get; set; }
        public int IdSistema { get; set; }
        public string nombreSistema { get; set; }
        public int activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerRolResponseDTO, ObtenerRolResponseViewModel>();
        }
    }
}
