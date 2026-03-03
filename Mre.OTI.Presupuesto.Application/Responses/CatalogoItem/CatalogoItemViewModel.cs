
namespace Mre.OTI.Presupuesto.Application.Responses.CatalogoItem
{
    public class CatalogoItemViewModel
    {
        public int idCatalogoItem { get; set; }
        public int idCatalogo { get; set; }

        public int codigoCatalogoItem { get; set; }
        //public int orden { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public string abreviaturaCatalogoItem { get; set; }
        public string detalleCatalogoItem { get; set; }
        /// <summary>
        /// para uso de integracion procesos
        /// </summary>
        public int id { get; set; }// = catalogoItem.idCatalogoItem,
        /// para uso de integracion procesos
        public int codigo { get; set; }// = catalogoItem.codigoCatalogoItem,
        /// para uso de integracion procesos
        public string descripcion { get; set; } //= catalogoItem.descripcionCatalogoItem

        public string CentroCostos { get; set; }
    }
  
}
