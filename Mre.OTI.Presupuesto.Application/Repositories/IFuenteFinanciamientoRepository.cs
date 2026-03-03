using Mre.OTI.Presupuesto.Application.DTO.FuenteFinanciamiento;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IFuenteFinanciamientoRepository
    {
        Task<IEnumerable<ObtenerListadoFuenteFinanciamientoResponseDTO>> ObtenerListadoFuente(ObtenerListadoFuenteFinanciamientoRequestDTO request);
    }
}
