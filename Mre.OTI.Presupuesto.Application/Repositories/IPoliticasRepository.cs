using Mre.OTI.Presupuesto.Application.DTO.Calendario;
using Mre.OTI.Presupuesto.Application.DTO.CentroCostos;
using Mre.OTI.Presupuesto.Application.DTO.Politicas;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IPoliticasRepository
    {
        Task<IEnumerable<ObtenerPoliticasPaginadoResponseDTO>> ObtenerPoliticasPaginado(ObtenerPoliticasPaginadoRequestDTO request);

        Task<ObtenerPoliticasResponseDTO> ObtenerPoliticas(ObtenerPoliticasRequestDTO request);

        Task<IEnumerable<ObtenerListadoPoliticasResponseDTO>> ObtenerListadoPoliticas(ObtenerListadoPoliticasRequestDTO request);

        Task<int> Guardar(Politicas parametro);

        Task<int> Actualizar(Politicas parametro);

        Task<int> Eliminar(Politicas parametro);

        Task<ObtenerCodigoPoliticasResponseDTO> ObtenerCodigoPoliticas(ObtenerCodigoPoliticasRequestDTO request);
    }
}
