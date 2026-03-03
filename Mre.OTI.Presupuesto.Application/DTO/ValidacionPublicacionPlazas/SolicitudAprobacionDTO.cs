namespace Mre.OTIv1.Application.DTO.ValidacionPublicacionPlazas
{
    public class SolicitudAprobacionDTO
    {
        public string codOtraEntidad { get; set; }
        public string codDre { get; set; }
        public string codUgel { get; set; }
        public string codigoProcesoAprobacion { get; set; }
        public string codTipoDocumentoSolicitante { get; set; }
        public string numeroDocumentoSolicitante { get; set; }
        public string link { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
        public long idRegistro { get; set; }
        public string solicitante { get; set; }
    }
}
