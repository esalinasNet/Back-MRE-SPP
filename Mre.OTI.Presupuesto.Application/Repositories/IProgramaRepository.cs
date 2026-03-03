using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Programa;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProgramaRepository
    {
        Task<IEnumerable<ObtenerProgramaPaginadoResponseDTO>> ObtenerProgramaPaginado(ObtenerProgramaPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerListadoProgramaResponseDTO>> ObtenerListadoPrograma(ObtenerListadoProgramaRequestDTO request);

        Task<int> Guardar(Programa parametro);

        Task<int> Actualizar(Programa parametro);

        Task<int> Eliminar(Programa parametro);

        Task<ObtenerProgramaResponseDTO> ObtenerPrograma(int idPrograma);
    }
}
