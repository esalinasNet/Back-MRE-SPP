using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.DTO.GrupoFuncional;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IGrupoFuncionalRepository
    {
        Task<IEnumerable<ObtenerGrupoFuncionalPaginadoResponseDTO>> ObtenerGrupoFuncionalPaginado(ObtenerGrupoFuncionalPaginadoRequestDTO request);

        Task<ObtenerGrupoFuncionalResponseDTO> ObtenerGrupoFuncional(ObtenerGrupoFuncionalRequestDTO request);

        Task<int> Guardar(GrupoFuncional parametro);

        Task<int> Actualizar(GrupoFuncional parametro);

        Task<int> Eliminar(GrupoFuncional parametro);

        Task<IEnumerable<ObtenerListadoGrupoFuncionalResponseDTO>> ObtenerListadoGrupoFuncional(ObtenerListadoGrupoFuncionalResquestDTO request);

        Task<ObtenerCodigoGrupoFuncionalResponseDTO> ObtenerCodigoGrupo(ObtenerCodigoGrupoFuncionalRequestDTO request);
    }
}
