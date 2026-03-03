namespace Mre.OTI.Presupuesto.Application.DTO.Persona
{
    public class ObtenerPersonaPaginadoResponseDTO
    {
        public int idPersona { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
        public int idTipoDocumento { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string fechaNacimiento { get; set; }
        public string paisNacimiento { get; set; }
        public int registro { get; set; }
        public int activo { get; set; }
        public int totalRegistro { get; set; }

    }
}
