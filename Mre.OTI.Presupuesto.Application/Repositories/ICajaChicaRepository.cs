using Mre.OTI.Presupuesto.Application.DTO.CajaChica;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ICajaChicaRepository
    {
        Task<IEnumerable<ObtenerListadoCajaChicaResponseDTO>> ObtenerListadoCajaChica(ObtenerListadoCajaChicaRequestDTO request);
        Task<IEnumerable<ObtenerCajaChicaPaginadoResponseDTO>> ObtenerCajaChicaPaginado(ObtenerCajaChicaPaginadoRequestDTO request);
        Task<ObtenerCajaChicaPorIdResponseDTO> ObtenerCajaChicaPorId(int idProgramacionCajaChica, string usuarioConsulta);
        Task<int> Guardar(CajaChica parametro);
        Task<int> Actualizar(CajaChica parametro);
        Task<int> Eliminar(CajaChica parametro);
    }
}
