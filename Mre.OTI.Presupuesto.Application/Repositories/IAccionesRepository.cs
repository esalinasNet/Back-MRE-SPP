using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IAccionesRepository
    {
        Task<IEnumerable<ObtenerAccionesPaginadoResponseDTO>> ObtenerAccionesPaginado(ObtenerAccionesPaginadoRequestDTO request);

        Task<ObtenerAccionesResponseDTO> ObtenerAcciones(ObtenerAccionesRequestDTO request);

        Task<int> Guardar(Acciones parametro);

        Task<int> Actualizar(Acciones parametro);

        Task<int> Eliminar(Acciones parametro);

        Task<ObtenerCodigoAccionesResponseDTO> ObtenerCodigoAcciones(ObtenerCodigoAccionesRequestDTO request);

        Task<IEnumerable<ObtenerListadoAccionesResponseDTO>> ObtenerListadoAcciones(ObtenerListadoAccionesRequestDTO request);
    }
}
