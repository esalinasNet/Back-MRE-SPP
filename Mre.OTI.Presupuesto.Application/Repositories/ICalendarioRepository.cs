using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ICalendarioRepository
    {
        Task<IEnumerable<ObtenerCalendarioPaginadoResponseDTO>> ObtenerCalendarioPaginado(ObtenerCalendarioPaginadoRequestDTO request);        

        Task<ObtenerCalendarioResponseDTO> ObtenerCalendario(ObtenerCalendarioRequestDTO request);
        
        Task<int> Guardar(Calendario parametro);

        Task<int> Actualizar(Calendario parametro);

        Task<int> Eliminar(Calendario parametro);

        Task<IEnumerable<ObtenerListadoCalendarioResponseDTO>> ObtenerListadoCalendario();
    }
}
