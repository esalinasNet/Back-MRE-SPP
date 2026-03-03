using Mre.OTI.Presupuesto.Application.DTO.Acciones;
using Mre.OTI.Presupuesto.Application.DTO.FasesPoi;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IFasesPoiRepository
    {
        Task<IEnumerable<ObtenerFasesPoiPaginadoResponseDTO>> ObtenerFasesPoiPaginado(ObtenerFasesPoiPaginadoRequestDTO request);

        Task<ObtenerFasesPoiResponseDTO> ObtenerFasesPoi(ObtenerFasesPoiRequestDTO request);

        Task<int> Guardar(FasesPoi parametro);

        Task<int> Actualizar(FasesPoi parametro);

        Task<int> Eliminar(FasesPoi parametro);

        Task<IEnumerable<ObtenerListadoFasesPoiResponseDTO>> ObtenerListadoFasesPoi(ObtenerListadoFasesPoiRequestDTO request);
    }
}
