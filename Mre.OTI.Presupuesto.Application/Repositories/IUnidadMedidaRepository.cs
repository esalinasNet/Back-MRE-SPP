using Mre.OTI.Presupuesto.Application.DTO.UnidadMedida;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IUnidadMedidaRepository
    {
        Task<IEnumerable<ObtenerUnidadMedidaPaginadoResponseDTO>> ObtenerUnidadMedidaPaginado(ObtenerUnidadMedidaPaginadoRequestDTO request);

        Task<ObtenerUnidadMedidaResponseDTO> ObtenerUnidadMedida(ObtenerUnidadMedidaRequestDTO request);

        Task<int> Guardar(UnidadMedida parametro);

        Task<int> Actualizar(UnidadMedida parametro);

        Task<int> Eliminar(UnidadMedida parametro);

        Task<IEnumerable<ObtenerListadoUnidadMedidaResponseDTO>> ObtenerListadoUnidadMedida(ObtenerListadoUnidadMedidaRequestDTO request);

        Task<ObtenerCodigoUnidadMedidaResponseDTO> ObtenerCodigoUnidadMedida(ObtenerCodigoUnidadMedidaRequestDTO request);
    }
}
