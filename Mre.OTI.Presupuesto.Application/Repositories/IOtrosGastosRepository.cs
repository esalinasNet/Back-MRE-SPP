using Mre.OTI.Presupuesto.Application.DTO.OtrosGastos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IOtrosGastosRepository
    {
        Task<IEnumerable<ObtenerListadoOtrosGastosResponseDTO>> ObtenerListadoOtrosGastos(ObtenerListadoOtrosGastosRequestDTO request);
        Task<IEnumerable<ObtenerOtrosGastosPaginadoResponseDTO>> ObtenerOtrosGastosPaginado(ObtenerOtrosGastosPaginadoRequestDTO request);
        Task<ObtenerOtrosGastosPorIdResponseDTO> ObtenerOtrosGastosPorId(int idProgramacionOtrosGastos, string usuarioConsulta);
        Task<int> Guardar(OtrosGastos parametro);
        Task<int> Actualizar(OtrosGastos parametro);
        Task<int> Eliminar(OtrosGastos parametro);
    }
}
