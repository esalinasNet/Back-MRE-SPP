namespace Mre.OTI.Presupuesto.Application.DTO.CatalogoItem
{
    public class ObtenerCatalogoItemPaginadoResponseDTO
    {
        //public int idCatalogo { get; set; }
        //public string nombreCatalogo { get; set; }
        //public int codigoCatalogo { get; set; }
        //public bool mantenible { get; set; }
        public int registro { get; set; }

        public int totalRegistro { get; set; }

        public int idCatalogoItem { get; set; }
        public int idCatalogo { get; set; }

        public int codigoCatalogoItem { get; set; }
        public int orden { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public string AbreviaturaCatalogoItem { get; set; }
        public string detalleCatalogoItem { get; set; }

        public bool eliminado { get; set; }




    }
}
