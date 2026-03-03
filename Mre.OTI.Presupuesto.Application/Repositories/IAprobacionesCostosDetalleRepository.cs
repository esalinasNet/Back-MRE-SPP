using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos_Detalle;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IAprobacionesCostosDetalleRepository
    {
        Task<IEnumerable<ObtenerAprobacionesCostosDetallePaginadoResponseDTO>> ObtenerAprobacionesCostosDetallePaginado(ObtenerAprobacionesCostosDetallePaginadoRequestDTO request);

        Task<ObtenerAprobacionesCostosDetalleResponseDTO> ObtenerAprobacionesCostosDetalle(ObtenerAprobacionesCostosDetalleRequestDTO request);

        Task<int> Guardar(AprobacionesCostosDetalle parametro);

        Task<int> Actualizar(AprobacionesCostosDetalle parametro);

        Task<int> Actualizar2(AprobacionesCostosDetalle parametro);

        Task<int> Eliminar(AprobacionesCostosDetalle parametro);

        //Task<ObtenerCodigoAprobacionesCostosDetalleResponseDTO> ObtenerCodigoAprobacionesCostosDetalle(ObtenerCodigoAprobacionesCostosDetalleRequestDTO request);

        //Task<IEnumerable<ObtenerListadoAprobacionesCostosDetalleResponseDTO>> ObtenerListadoAprobacionesCostosDetalle(ObtenerListadoAprobacionesCostosDetalleRequestDTO request);

    }
}
