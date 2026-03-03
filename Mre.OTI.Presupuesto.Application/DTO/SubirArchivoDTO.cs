namespace Mre.OTI.Presupuesto.Application.DTO
{
    public class SubirArchivoDTO
    {
        public int codigoSistema { get; set; }
        public string descripcionDocumento { get; set; }
        public string codigoUsuarioCreacion { get; set; }
        public byte[] archivo { get; set; }
        public string nombreArchivo { get; set; }
    }
}
