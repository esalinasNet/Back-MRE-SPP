using MediatR;
using Mre.OTI.Presupuesto.Application.Responses.Persona;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Queries
{
    public class ObtenerPersonaPaginadoViewModel : IRequest<dtPersonaPaginadoResponseViewModel>
    {
        public int idTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        
        public int idPaisNacimiento { get; set; }
        public string usuarioConsulta { get; set; }
        public bool? activo { get; set; }
        public int draw { get; set; }


        public int paginaActual { get; set; }
        public int tamanioPagina { get; set; }
    }
}
