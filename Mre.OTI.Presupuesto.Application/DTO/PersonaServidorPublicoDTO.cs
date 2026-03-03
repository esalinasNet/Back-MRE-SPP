using System;

namespace Mre.OTIv1.Application.DTO
{
    public class PersonaServidorPublicoDTO
    {
        public string instancia { get; set; }
        public string subInstancia { get; set; }
        public string centroTrabajo { get; set; }
        public string modalidad { get; set; }
        public string nivelEducativo { get; set; }
        public string regimenLaboral { get; set; }
        public string condicionLaboral { get; set; }
        public string cargo { get; set; }
        public string areaCurricular { get; set; }
        public string jornadaLaboral { get; set; }
        public DateTime? fechaIni { get; set; }
        public DateTime? fechaFin { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumentoIdentidad { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string nombres { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string telefonoMovil { get; set; }
        public string email { get; set; }
        public long? idPersona { get; set; }
        public int? idCargo { get; set; }
    }
}
