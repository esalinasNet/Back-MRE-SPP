namespace Mre.OTIv1.Application.DTO.LogSeguimiento
{
    public class ObtenerListadoLogSeguimientoResponseDTO
    {
        public int idLogSeguimiento { get; set; }
        public int codigoTipoSolicitud { get; set; }
        public int codigoSubtipoSolicitud { get; set; }
        public int idEstadoSolicitud { get; set; }
        public string estadoSolicitud { get; set; }
        public int idSolicitud { get; set; }
        public string comentario { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }

    }
}
