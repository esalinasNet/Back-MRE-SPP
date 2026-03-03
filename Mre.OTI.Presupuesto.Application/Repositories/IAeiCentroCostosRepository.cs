using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.AeiCentroCostos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IAeiCentroCostosRepository
    {
        //Task<EliminaAeiCentroCostosResponseDTO> EliminaAeiCentroCostos(EliminaAeiCentroCostosRequestDTO request);

        Task<IEnumerable<ObtenerAeiCentroCostosPaginadoResponseDTO>> ObtenerAeiCentroCostosPaginado(ObtenerAeiCentroCostosPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerAeiCentroCostosResponseDTO>> ObtenerAeiCentroCostos(ObtenerAeiCentroCostosRequestDTO request);

        Task<int> Guardar(AeiCentroCostos parametro);

        Task<int> Eliminar(AeiCentroCostos parametro);
    }
}
