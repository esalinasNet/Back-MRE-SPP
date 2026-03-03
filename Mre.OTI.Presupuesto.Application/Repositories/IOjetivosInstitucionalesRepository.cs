using Mre.OTI.Presupuesto.Application.DTO.Objetivos;
using Mre.OTI.Presupuesto.Application.DTO.ObjetivosInstitucionales;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IOjetivosInstitucionalesRepository
    {
        Task<IEnumerable<ObtenerObjetivosInstitucionalesPaginadoResponseDTO>> ObtenerObjetivosInstitucionalesPaginado(ObtenerObjetivosInstitucionalesPaginadoRequestDTO request);

        Task<ObtenerObjetivosInstitucionalesResponseDTO> ObtenerObjetivosInstitucionales(ObtenerObjetivosInstitucionalesRequestDTO request);

        Task<int> Guardar(ObjetivosInstitucionaales parametro);

        Task<int> Actualizar(ObjetivosInstitucionaales parametro);

        Task<int> Eliminar(ObjetivosInstitucionaales parametro);

        Task<ObtenerCodigoObjetivosInstitucionalesResponseDTO> ObtenerCodigoObjetivosInstitucioanles(ObtenerCodigoObjetivosInstitucionalesRequestDTO request);

        Task<IEnumerable<ObtenerListadoObjetivosInstitucionalesResponseDTO>> ObtenerListadoObjetivosInstitucionales(ObtenerListadoObjetivosInstitucionalesRequestDTO request);
    }
}
