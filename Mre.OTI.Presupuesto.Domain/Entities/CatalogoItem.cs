using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class CatalogoItem : Auditoria
    {
        public int idCatalogoItem { get; set; }
        public int idCatalogo { get; set; }

        public int codigoCatalogoItem { get; set; }
        public int orden { get; set; }
        public string descripcionCatalogoItem { get; set; }
        public string AbreviaturaCatalogoItem { get; set; }
        public string detalleCatalogoItem { get; set; }

        public bool eliminado { get; set; }

        public int registro { get; set; }

        public int totalRegistro { get; set; }

    }
}
