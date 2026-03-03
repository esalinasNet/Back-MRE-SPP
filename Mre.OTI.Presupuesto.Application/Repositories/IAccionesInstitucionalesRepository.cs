using Mre.OTI.Presupuesto.Application.DTO.AccionesInstitucionales;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IAccionesInstitucionalesRepository
    {
        Task<IEnumerable<ObtenerAccionesInstitucionalesPaginadoResponseDTO>> ObtenerAccionesInstitucionalesPaginado(ObtenerAccionesInstitucionalesPaginadoRequestDTO request);

        Task<ObtenerAccionesInstitucionalesResponseDTO> ObtenerAccionesInstitucionales(ObtenerAccionesInstitucionalesRequestDTO request);

        Task<int> Guardar(AccionesInstitucionales parametro);

        Task<int> Actualizar(AccionesInstitucionales parametro);

        Task<int> Eliminar(AccionesInstitucionales parametro);

        Task<int> ActualizarAEICostos(AccionesInstitucionales parametro);

        Task<ObtenerCodigoAccionesResponseDTO> ObtenerCodigoAcciones(ObtenerCodigoAccionesRequestDTO request);

        Task<IEnumerable<ObtenerListadoAccionesInstitucionalesResponseDTO>> ObtenerListadoAcciones(ObtenerListadoAccionesInstitucionalesRequestDTO request);
    }
}
