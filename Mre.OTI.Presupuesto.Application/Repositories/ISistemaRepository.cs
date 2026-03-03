using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Sistema;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ISistemaRepository
    {
        Task<IEnumerable<ObtenerSistemaPaginadoResponseDTO>> ObtenerSistemaPaginado(ObtenerSistemaPaginadoRequestDTO request);
        Task<IEnumerable<ObtenerListadoSistemaResponseDTO>> ObtenerListadoSistema();

        Task<int> Guardar(Sistema parametro);

        Task<int> Actualizar(Sistema parametro);

        Task<int> Eliminar(Sistema parametro);

        Task<ObtenerSistemaResponseDTO> ObtenerSistema(int idSistema);
    }
}
