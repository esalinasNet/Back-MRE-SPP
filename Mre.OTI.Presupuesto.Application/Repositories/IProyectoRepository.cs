using Mre.OTI.Presupuesto.Application.DTO.Proyecto;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IProyectoRepository
    {
        Task<IEnumerable<ObtenerListadoProyectoResponseDTO>> ObtenerListadoProyecto(ObtenerListadoProyectoRequestDTO parametro);
        Task<IEnumerable<ObtenerProyectoPaginadoResponseDTO>> ObtenerProyectoPaginado(ObtenerProyectoPaginadoRequestDTO parametro);
        Task<ObtenerProyectoPorIdResponseDTO> ObtenerProyectoPorId(int idProgramacionProyecto, string usuarioConsulta);
        Task<int> Guardar(Proyecto parametro);
        Task<int> Actualizar(Proyecto parametro);
        Task<int> Eliminar(Proyecto parametro);
    }
}
