using Mre.OTI.Presupuesto.Application.DTO.Services;
//using Mre.OTI.Presupuesto.Application.Responses.AccionPersonal;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories.Services
{
    public interface IAccionesGrabadasService
    {
        Task<ProyectoResolucionGenerarDirectoResponseDTO> GenerarProyectoResolucion(ProyectoResolucionGenerarDirectoRequestDTO request);
        // Task<int> MandarAccionesGrabadasDirecto(List<AccionesGrabadasViewModel> accionesGrabadasRequest);

        //  Task<ProyectoResolucionGenerarDirectoResponseDTO> EnviarGuardarProyectoResolucionDirecto(ProyectoResolucionRequestViewModel proyectoResolucionRequest);
    }
}
