namespace Mre.OTI.Presupuesto.Application.DTO.CatalogoItem
{
    public class ObtenerCatalogoItemResponseDTO
    {
        public int idCatalogoItem { get; set; }
        public int codigoCatalogoItem { get; set; }
        public int idCatalogo { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public string abreviaturaCatalogoItem { get; set; }
        public string detalleCatalogoItem { get; set; }
    }
}
