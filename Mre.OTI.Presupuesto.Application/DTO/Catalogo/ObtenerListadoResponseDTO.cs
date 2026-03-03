namespace Mre.OTI.Presupuesto.Application.DTO.Catalogo
{
    public class ObtenerListadoResponseDTO
    {
        public int idCatalogo { get; set; }
        public string nombreCatalogo { get; set; }
        public int codigoCatalogo { get; set; }
        public bool mantenible { get; set; }
    }
}
