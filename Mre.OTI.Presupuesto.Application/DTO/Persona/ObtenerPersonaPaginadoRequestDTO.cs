using Mre.OTI.Presupuesto.Application.Base.DTO;

namespace Mre.OTI.Presupuesto.Application.DTO.Persona
{
    public class ObtenerPersonaPaginadoRequestDTO : Pagination
    {
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public int idTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public int idPaisNacimiento { get; set; }
        public bool? activo { get; set; }
    }
}
