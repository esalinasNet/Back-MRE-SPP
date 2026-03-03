using Mre.OTI.Presupuesto.Application.DTO.Planillas_Detalle;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IPlanillasDetalleRepository
    {
        Task<IEnumerable<ObtenerPlanillasDetallePaginadoResponseDTO>> ObtenerPlanillasDetallePaginado(ObtenerPlanillasDetallePaginadoRequestDTO request);

        Task<ObtenerPlanillasDetalleResponseDTO> ObtenerPlanillasDetalle(ObtenerPlanillasDetalleRequestDTO request);

        Task<int> Guardar(PlanillasDetalle parametro);

        Task<int> Actualizar(PlanillasDetalle parametro);

        Task<int> Eliminar(PlanillasDetalle parametro);

        //Task<ObtenerCodigoPlanillasDetalleResponseDTO> ObtenerCodigoPlanillasDetalle(ObtenerCodigoPlanillasDetalleRequestDTO request);

        //Task<IEnumerable<ObtenerListadoPlanillasDetalleResponseDTO>> ObtenerListadoPlanillasDetalle(ObtenerListadoPlanillasDetalleRequestDTO request);
    }
}
