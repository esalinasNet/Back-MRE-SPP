using Mre.OTI.Presupuesto.Application.DTO;
using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IOjetivosRepository
    {
        Task<IEnumerable<ObtenerObjetivosPaginadoResponseDTO>> ObtenerObjetivosPaginado(ObtenerObjetivosPaginadoRequestDTO request);

        Task<ObtenerObjetivosResponseDTO> ObtenerObjetivos(ObtenerObjetivosRequestDTO request);

        Task<IEnumerable<ObtenerListadoObjetivosResponseDTO>> ObtenerListadoObjetivos(ObtenerListadoObjetivosRequestDTO request);

        Task<int> Guardar(Objetivos parametro);

        Task<int> Actualizar(Objetivos parametro);

        Task<int> Eliminar(Objetivos parametro);

        Task<ObtenerCodigoObjetivosResponseDTO> ObtenerCodigoObjetivos(ObtenerCodigoObjetivosRequestDTO request);
    }
}
