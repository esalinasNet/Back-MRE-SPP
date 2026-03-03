using Mre.OTI.Presupuesto.Application.DTO.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IEspecificaGastoRepository
    {
        Task<IEnumerable<ObtenerEspecificaGastoPaginadoResponseDTO>> ObtenerEspecificaGastoPaginado(ObtenerEspecificaGastoPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerListadoEspecificaGastoResponseDTO>> ObtenerListadoEspecificaGasto(ObtenerListadoEspecificaGastoRequestDTO request);

        Task<int> Guardar(EspecificaGasto parametro);

        Task<int> Actualizar(EspecificaGasto parametro);

        Task<int> Eliminar(EspecificaGasto parametro);

        Task<ObtenerEspecificaGastoResponseDTO> ObtenerEspecificaGasto(int idClasificador);

        Task<ObtenerClasificadorResponseDTO> ObtenerClasificador(string Clasificador);

        Task<IEnumerable<ObtenerListadoEspecificaGastoGenericaResponseDTO>> ObtenerListadoEspecificaGastoGenerica(ObtenerListadoEspecificaGastoGenericaRequestDTO request);
    }
}
