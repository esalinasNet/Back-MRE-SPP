namespace Mre.OTI.Presupuesto.Application.DTO.Persona
{
    public class ObtenerListadoPersonaResponseDTO
    {
        public int idPersona { get; set; }
        public int idTipoDocumento { get; set; }
        public int idPaisNacimiento { get; set; }
        public int idEstadoCivil { get; set; }
        public string nombres { get; set; }
        public string numeroDocumento { get; set; }
        public string sexo { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correo { get; set; }
    }
}
