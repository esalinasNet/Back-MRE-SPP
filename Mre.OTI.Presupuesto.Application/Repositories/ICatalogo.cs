using Mre.OTI.Presupuesto.Application.DTO.Catalogo;
using Mre.OTI.Presupuesto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ICatalogoRepository
    {
        Task<int> Guardar(Catalogo parametro);
        Task<int> Eliminar(Catalogo parametro);
        Task<int> Actualizar(Catalogo parametro);
        Task<ObtenerCatalogoResponseDTO> ObtenerCatalogo(int idCatalogo);
        Task<IEnumerable<Catalogo>> ObtenerCatalogoPaginado(ObtenerCatalogoPaginadoRequestDTO request);

        Task<IEnumerable<Catalogo>> ObtenerListadoCatalogo();

        Task<ObtenerCatalogoValResponseDTO> ObtenerCatalogoVal(ObtenerCatalogoValRequestDTO request);
   
    }
}
