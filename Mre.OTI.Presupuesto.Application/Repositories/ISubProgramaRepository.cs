using Mre.OTI.Presupuesto.Application.DTO.Programa;
using Mre.OTI.Presupuesto.Application.DTO.SubPrograma;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ISubProgramaRepository
    {
        Task<IEnumerable<ObtenerSubProgramaPaginadoResponseDTO>> ObtenerSubProgramaPaginado(ObtenerSubProgramaPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerListadoSubProgramaResponseDTO>> ObtenerListadoSubPrograma();

        Task<int> Guardar(SubPrograma parametro);

        Task<int> Actualizar(SubPrograma parametro);

        Task<int> Eliminar(SubPrograma parametro);

        Task<ObtenerSubProgramaResponseDTO> ObtenerSubPrograma(int idSubPrograma);
    }
}