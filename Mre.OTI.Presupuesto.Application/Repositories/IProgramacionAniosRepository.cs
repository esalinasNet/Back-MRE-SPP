using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAnios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProgramacionAniosRepository
    {
        Task<CopiarProgramacionAniosResponseDTO> CopiarProgramacion(
            int anioOrigen,
            List<int> aniosDestino,
            List<int> actividades,
            string usuarioCreacion);
    }
}