using Mre.OTI.Presupuesto.Application.DTO.CatalogoItem;
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ICatalogoItemRepository
    {
        Task<int> Eliminar(CatalogoItem parametro);
        Task<int> Actualizar(CatalogoItem parametro);
        Task<int> Guardar(CatalogoItem parametro);
        Task<IEnumerable<dynamic>> ObtenerCatalogoItemsXCodigoCatalogo(int codigoCatalogo);
        Task<ObtenerCatalogoItemResponseDTO> ObtenerCatalogoItemsActivosXIdCatalogoItem(int idCatalogoItem);
        //   Task<int> ObtenerCodigoCatalogoItemPorCodigoCatalogoYIdCatalogoItem(int codigoCatalogo, int? idCatalogoItem);
        //ObtenerCatalogoItemsActivosXIdCatalogoItem
        Task<int> ObtenerIdCatalogoItem(int codigoCatalogo, int codigoCatalogoItem);
        Task<int> ObtenerCodigoCatalogoItem(int idCatalogoItem);
        //Task<int> ObtenerIdCatalogo(int codigoCatalogo);
        //Task<IEnumerable<dynamic>> ListarIdPorCodigoCatalogo(int codigoCatalogo, int? codigoCatalogoItem = null);
        //Task<int> ObtenerCodigoCatalogoItemPorDNIText(int codigoCatalogo, string strDNI);
        Task<int> ObtenerNumeroOrderCatalogo(int idCatalogo);
        Task<IEnumerable<CatalogoItem>> ObtenerCatalogoItemPaginado(ObtenerCatalogoItemPaginadoRequestDTO request);

        Task<ObtenerCatalogoItemValResponseDTO> ObtenerCatalogoItemVal(ObtenerCatalogoItemValRequestDTO request);
    }
}
