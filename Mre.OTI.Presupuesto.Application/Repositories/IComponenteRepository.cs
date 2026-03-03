using Mre.OTI.Presupuesto.Application.DTO.Componente;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IComponenteRepository
    {
        Task<IEnumerable<ObtenerComponentePaginadoResponseDTO>> ObtenerComponentePaginado(ObtenerComponentePaginadoRequestDTO request);
        Task<IEnumerable<ObtenerListadoComponenteResponseDTO>> ObtenerListadoComponente();

        Task<int> Guardar(Componente parametro);

        Task<int> Actualizar(Componente parametro);

        Task<int> Eliminar(Componente parametro);
        Task<ObtenerComponenteResponseDTO> ObtenerComponente(int idComponente);
    }
}
