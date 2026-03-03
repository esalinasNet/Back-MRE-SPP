namespace Mre.OTIv1.Application.DTO
{
    public class ResultadoServidorPublicoDTO
    {
        public int idServidorPublico { get; set; }
        public int idPersona { get; set; }
        public string tipoDocumentoIdentidad { get; set; }
        public string numeroDocumentoIdentidad { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string fechaNacimiento { get; set; }
        public string generoPersona { get; set; }
        public string codigoPlaza { get; set; }
        public long codigoServidorPublico { get; set; }
        public string situacionLaboral { get; set; }

    }

    public class ResultadoServidorPublicoGridPaginadoDTO
    {
        public int totalRegistros { get; set; }
        public int numeroRegistro { get; set; }
        public int idServidorPublico { get; set; }
        public string tipoDocumentoIdentidad { get; set; }
        public int idTipoDocumentoIdentidad { get; set; }
        public string numeroDocumentoIdentidad { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string fechaNacimiento { get; set; }
        public string iged { get; set; }
        public string regimenLaboral { get; set; }
        public string centroTrabajo { get; set; }
        public string condicionLaboral { get; set; }
        public string fechaConsultaReniec { get; set; }
        public string estado { get; set; }
    }
}