namespace Mre.OTI.Presupuesto.Application.DTO.Catalogo
{
    public class ObtenerCatalogoPaginadoResponseDTO
    {
        public int idCatalogo { get; set; }
        public string nombreCatalogo { get; set; }
        public int codigoCatalogo { get; set; }
        public bool mantenible { get; set; }
        public int registro { get; set; }

        public int totalRegistro { get; set; }

    }
}
