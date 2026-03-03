using AutoMapper;
using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Application.Mapper;

namespace Mre.OTI.Presupuesto.Application.Responses.Persona
{
    public class ObtenerPersonaResponseViewModel : IMapFrom<ObtenerPersonaResponseDTO>
    {
        public int idPersona { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
        public int idTipoDocumento { get; set;}
        public int idEstadoCivil { get; set; }
        public int idPaisNacimiento { get; set; }
        public string tipoDocumento { get; set; }
        public string fechaNacimiento { get; set; }
        public string numeroDocumento { get; set; }
        public string paisNacimiento {get;set;}
        public string estadoCivil { get; set; }
        public string sexo { get; set; }
        public string numeroTelefono { get; set; }
        public int activo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ObtenerPersonaResponseDTO, ObtenerPersonaResponseViewModel>();
        }
    }
}
