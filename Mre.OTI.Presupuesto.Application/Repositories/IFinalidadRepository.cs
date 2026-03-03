using Mre.OTI.Presupuesto.Application.DTO.Finalidad;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IFinalidadRepository
    {
        Task<IEnumerable<ObtenerFinalidadPaginadoResponseDTO>> ObtenerFinalidadPaginado(ObtenerFinalidadPaginadoRequestDTO request);

        Task<ObtenerFinalidadResponseDTO> ObtenerFinalidad(ObtenerFinalidadRequestDTO request);

        Task<int> Guardar(Finalidad parametro);

        Task<int> Actualizar(Finalidad parametro);

        Task<int> Eliminar(Finalidad parametro);

        Task<IEnumerable<ObtenerListadoFinalidadResponseDTO>> ObtenerListadoFinalidad(ObtenerListadoFinalidadRequestDTO request);

        Task<ObtenerCodigoFinalidadResponseDTO> ObtenerCodigoFinalidad(ObtenerCodigoFinalidadRequestDTO request);
    }
}
