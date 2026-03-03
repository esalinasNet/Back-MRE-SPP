using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Application.Mapper;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.Usuario
{
    public class ObtenerUsuarioPaginadoResponseViewModel : IMapFrom<ObtenerUsuarioPaginadoResponseDTO>
    {
        public int idUsuario { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
        public int activo { get; set; }
        public int registro { get; set; }

        public int totalRegistro { get; set; }

        public string usuarioNT { get; set; }
        public string numeroDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public string tipoDocumento { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerUsuarioPaginadoResponseDTO, ObtenerUsuarioPaginadoResponseViewModel>();
        }
    }

    public class dtUsuarioPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerUsuarioPaginadoResponseViewModel> data { get; set; }
    }
}
