using Mre.OTI.Presupuesto.Application.Base.DTO;

namespace Mre.OTI.Presupuesto.Application.DTO.Catalogo
{
    public class ObtenerCatalogoPaginadoRequestDTO : Pagination
    {
        public int idCatalogo { get; set; }
        public string nombreCatalogo { get; set; }



    }
}
