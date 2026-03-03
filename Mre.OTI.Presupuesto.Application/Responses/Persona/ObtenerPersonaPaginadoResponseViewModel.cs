using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Application.Mapper;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.Responses.Persona
{
    public class ObtenerPersonaPaginadoResponseViewModel : IMapFrom<ObtenerPersonaPaginadoResponseDTO>
    {
        public int idPersona { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
        public string paisNacimiento { get; set; }
        public int activo { get; set; }
        public string numeroDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public string tipoDocumento { get; set; }
 
        public int registro { get; set; }

        public int totalRegistro { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerPersonaPaginadoResponseDTO, ObtenerPersonaPaginadoResponseViewModel>();
        }
    }

    public class dtPersonaPaginadoResponseViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public IEnumerable<ObtenerPersonaPaginadoResponseViewModel> data { get; set; }
    }
}
