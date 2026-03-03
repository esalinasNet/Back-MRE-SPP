using Mre.OTI.Presupuesto.Application.DTO.Actividad;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IActividadRepository
    {
        Task<IEnumerable<ObtenerActividadPaginadoResponseDTO>> ObtenerActividadPaginado(ObtenerActividadPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerListadoActividadResponseDTO>> ObtenerListadoActividad(ObtenerListadoActividadRequestDTO request);

        Task<int> Guardar(Actividad parametro);

        Task<int> Actualizar(Actividad parametro);

        Task<int> Eliminar(Actividad parametro);

        Task<ObtenerActividadResponseDTO> ObtenerActividad(int idActividad);
    }
}
