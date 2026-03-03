using Mre.OTI.Presupuesto.Application.DTO.Anio;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IAniosRepository
    {
        Task<IEnumerable<ObtenerAniosPaginadoResponseDTO>> ObtenerAniosPaginado(ObtenerAniosPaginadoRequestDTO request);
        Task<IEnumerable<ObtenerListadoAniosResponseDTO>> ObtenerListadoAnios();

        Task<int> Guardar(Anios parametro);

        Task<int> Actualizar(Anios parametro);

        Task<int> Eliminar(Anios parametro);

        Task<ObtenerAniosResponseDTO> ObtenerAnios(int idAnios);
    }
}
