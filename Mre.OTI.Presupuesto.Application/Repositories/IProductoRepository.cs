using Mre.OTI.Presupuesto.Application.DTO.ProductoProyecto;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<ObtenerProductoPaginadoResponseDTO>> ObtenerProductoPaginado(ObtenerProductoPaginadoRequestDTO request);

        Task<ObtenerProductoResponseDTO> ObtenerProducto(ObtenerProductoRequestDTO request);

        Task<int> Guardar(Producto parametro);

        Task<int> Actualizar(Producto parametro);

        Task<int> Eliminar(Producto parametro);

        Task<IEnumerable<ObtenerListadoProductoResponseDTO>> ObtenerListadoProducto(ObtenerListadoProductoRequestDTO request);

        Task<ObtenerCodigoProductoResponseDTO> ObtenerCodigoProducto(ObtenerCodigoProductoRequestDTO request);
    }
}
