using Mre.OTI.Presupuesto.Application.DTO.Cmn;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ICmnRepository
    {
        Task<IEnumerable<ObtenerListadoCmnResponseDTO>> ObtenerListadoCmn(ObtenerListadoCmnRequestDTO request);
        Task<IEnumerable<ObtenerCmnPaginadoResponseDTO>> ObtenerCmnPaginado(ObtenerCmnPaginadoRequestDTO request);
        Task<ObtenerCmnPorIdResponseDTO> ObtenerCmnPorId(int idProgramacionCmn, string usuarioConsulta);
        Task<int> Guardar(Cmn parametro);
        Task<int> Actualizar(Cmn parametro);
        Task<int> Eliminar(Cmn parametro);
    }
}
