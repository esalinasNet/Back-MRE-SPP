using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ITipoDeCambioRepository
    {
        Task<IEnumerable<ObtenerTipoDeCambioPaginadoResponseDTO>> ObtenerTipoDeCambioPaginado(ObtenerTipoDeCambioPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerListadoTipoDeCambioResponseDTO>> ObtenerListadoTipoDeCambio(ObtenerListadoTipoDeCambioRequestDTO request);

        Task<int> Guardar(TipoDeCambio parametro);

        Task<int> Actualizar(TipoDeCambio parametro);

        Task<ObtenerTipoDeCambioResponseDTO> ObtenerTipoDeCambio(ObtenerTipoDeCambioRequestDTO request);

        Task<IEnumerable<ObtenerTipoDeCambioMonedaResponseDTO>> ObtenerListadoTipoDeCambioMoneda(ObtenerTipoDeCambioMonedaRequestDTO request);
    }
}
