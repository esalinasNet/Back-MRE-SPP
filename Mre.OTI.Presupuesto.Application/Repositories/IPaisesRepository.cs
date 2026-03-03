using Mre.OTI.Presupuesto.Application.DTO.Paises;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IPaisesRepository
    {
        Task<IEnumerable<ObtenerPaisesPaginadoResponseDTO>> ObtenerPaisesPaginado(ObtenerPaisesPaginadoRequestDTO request);
        Task<IEnumerable<ObtenerListadoPaisesResponseDTO>> ObtenerListadoPaises();

        Task<int> Guardar(Paises parametro);

        Task<int> Actualizar(Paises parametro);

        Task<int> Eliminar(Paises parametro);

        Task<ObtenerPaisesResponseDTO> ObtenerPaises(int idPaises);
    }
}
