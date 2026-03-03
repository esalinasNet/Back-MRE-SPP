using Mre.OTI.Presupuesto.Application.DTO.Viaticos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IViaticosRepository
    {
        Task<IEnumerable<ObtenerListadoViaticosResponseDTO>> ObtenerListadoViaticos(ObtenerListadoViaticosRequestDTO request);
        Task<IEnumerable<ObtenerViaticoPaginadoResponseDTO>> ObtenerViaticoPaginado(ObtenerViaticoPaginadoRequestDTO request);
        Task<ObtenerViaticoPorIdResponseDTO> ObtenerViaticoPorId(int idProgramacionViaticos, string usuarioConsulta);
        Task<int> Guardar(Viaticos parametro);
        Task<int> Actualizar(Viaticos parametro);
        Task<int> Eliminar(Viaticos parametro);
    }
}
