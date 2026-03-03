namespace Mre.OTI.Presupuesto.Application.DTO.SubirDocumentoService
{
    public class SubirDocumentoDTO
    {
        public int codigoSistema { get; set; }
        public string descripcionDocumento { get; set; }
        public string codigoUsuarioCreacion { get; set; }
        public byte[] archivo { get; set; }
        public string nombreArchivo { get; set; }
    }
}
