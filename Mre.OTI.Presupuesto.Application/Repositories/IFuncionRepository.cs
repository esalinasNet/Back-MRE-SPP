using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Persona;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IFuncionRepository
    {
        Task<IEnumerable<ObtenerFuncionPaginadoResponseDTO>> ObtenerFuncionPaginado(ObtenerFuncionPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerListadoFuncionResponseDTO>> ObtenerListadoFuncion(ObtenerListadoFuncionRequestDTO request);

        Task<int> Guardar(Funcion parametro);

        Task<int> Actualizar(Funcion parametro);

        Task<int> Eliminar(Funcion parametro);

        Task<ObtenerFuncionResponseDTO> ObtenerFuncion(int idFuncion);
    }
}
