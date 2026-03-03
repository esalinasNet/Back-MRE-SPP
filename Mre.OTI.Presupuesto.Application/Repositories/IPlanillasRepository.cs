using Mre.OTI.Presupuesto.Application.DTO.Planillas;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{   
    public interface IPlanillasRepository
    {
        Task<IEnumerable<ObtenerPlanillasPaginadoResponseDTO>> ObtenerPlanillasPaginado(ObtenerPlanillasPaginadoRequestDTO request);

        Task<ObtenerPlanillasResponseDTO> ObtenerPlanillas(ObtenerPlanillasRequestDTO request);

        Task<int> Guardar(Planillas parametro);

        Task<int> Actualizar(Planillas parametro);

        Task<int> Eliminar(Planillas parametro);

        Task<ObtenerCodigoPlanillasResponseDTO> ObtenerCodigoPlanillas(ObtenerCodigoPlanillasRequestDTO request);

        Task<IEnumerable<ObtenerListadoPlanillasResponseDTO>> ObtenerListadoPlanillas(ObtenerListadoPlanillasRequestDTO request);
    }
}
