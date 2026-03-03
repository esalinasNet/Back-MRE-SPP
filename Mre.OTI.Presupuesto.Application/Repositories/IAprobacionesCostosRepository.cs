using Mre.OTI.Presupuesto.Application.DTO.AprobacionesCostos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IAprobacionesCostosRepository
    {
        Task<IEnumerable<ObtenerAprobacionesCostosPaginadoResponseDTO>> ObtenerAprobacionesCostosPaginado(ObtenerAprobacionesCostosPaginadoRequestDTO request);

        Task<ObtenerAprobacionesCostosResponseDTO> ObtenerAprobacionesCostos(ObtenerAprobacionesCostosRequestDTO request);

        Task<int> Guardar(AprobacionesCostos parametro);

        Task<int> Actualizar(AprobacionesCostos parametro);

        Task<int> Eliminar(AprobacionesCostos parametro);

        Task<ObtenerAprobacionesCentroCostosResponseDTO> ObtenerAprobacionesCentroCostos(ObtenerAprobacionesCentroCostosRequestDTO request);

        Task<IEnumerable<ObtenerListadoAprobacionesCostosResponseDTO>> ObtenerListadoAprobacionesCostos(ObtenerListadoAprobacionesCostosRequestDTO request);
    }
}
