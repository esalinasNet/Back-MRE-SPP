using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.DTO.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ICentroCostosRepository
    {
        Task<IEnumerable<ObtenerCentroCostosPaginadoResponseDTO>> ObtenerCentroCostosPaginado(ObtenerCentroCostosPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerListadoCentroCostosResponseDTO>> ObtenerListadoCentroCostos(ObtenerListadoCentroCostosRequestDTO request);

        Task<ObtenerCentroCostosResponseDTO> ObtenerCentroCostos(ObtenerCentroCostosRequestDTO request);        

        Task<int> Guardar(CentroCostos parametro);

        Task<int> Actualizar(CentroCostos parametro);

        Task<int> Eliminar(CentroCostos parametro);

        Task<ObtenerCentroCostosResponseDTO> ObtenerCodigoCostos(string centroCostos);
    }
}
