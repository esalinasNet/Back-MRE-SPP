using Mre.OTIv1.Application.Base.DTO;

namespace Mre.OTIv1.Application.DTO
{
    public class BusquedaServidorPublicoDTO
    {
        public int? idTipoDocumentoIdentidad { get; set; }
        public int? idSituacionLaboral { get; set; }
        public string numeroDocumentoIdentidad { get; set; }

    }
    public class BusquedaPersonaServidorPublicoDTO
    {
        public int idPersona { get; set; }
        public int idServidorPublico { get; set; }

    }

    public class BusquedaServidorPublicoGridPaginadoDTO : Pagination
    {
        public int? idTipoDocumentoIdentidad { get; set; }
        public string numeroDocumentoIdentidad { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public int? idInstancia { get; set; }
        public int? idSubInstancia { get; set; }
        public string codigoCentroTrabajo { get; set; }
    }
}