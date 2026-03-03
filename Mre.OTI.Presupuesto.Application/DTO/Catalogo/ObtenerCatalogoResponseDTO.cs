namespace Mre.OTI.Presupuesto.Application.DTO.Catalogo
{
    public class ObtenerCatalogoResponseDTO
    {
        public int idCatalogo { get; set; }
        public string descripcionCatalogo { get; set; }
        public string codigoCatalogo { get; set; }
        public bool manteniblePorUsuario { get; set; }
        public bool activo { get; set; }



    }
}
