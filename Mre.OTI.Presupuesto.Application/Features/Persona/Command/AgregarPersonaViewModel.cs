using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Command;
using System;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Command
{
    public class AgregarPersonaViewModel : IRequest<CommandResponseViewModel>
    {

        public int idTipoDocumento { get; set; }
        public int idPaisNacimiento { get; set; }
        public int idEstadoCivil { get; set; }
        public string numeroDocumento { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
        public string sexo { get; set; }
        public string numeroTelefono { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }


    }
}
