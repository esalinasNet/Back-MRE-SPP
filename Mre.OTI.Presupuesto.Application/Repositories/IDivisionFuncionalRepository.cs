using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IDivisionFuncionalRepository
    {
        Task<IEnumerable<ObtenerDivisionFuncionalPaginadoResponseDTO>> ObtenerDivisionFuncionalPaginado(ObtenerDivisionFuncionalPaginadoRequestDTO request);

        Task<ObtenerDivisionFuncionalResponseDTO> ObtenerDivisionFuncional(ObtenerDivisionFuncionalRequestDTO request);

        Task<IEnumerable<ObtenerListadoDivisionFuncionalResponseDTO>> ObtenerListadoDivisionFuncional(ObtenerListadoDivisionFuncionalRequestDTO request);

        Task<int> Guardar(DivisionFuncional parametro);

        Task<int> Actualizar(DivisionFuncional parametro);

        Task<int> Eliminar(DivisionFuncional parametro);

        Task<ObtenerCodigoDivisionResponseDTO> ObtenerCodigoDivision(ObtenerCodigoDivisionRequestDTO request);
    }
}
