using Mre.OTI.Presupuesto.Application.DTO.CategoriaPresupuestal;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ICategoriaPresupuestalRepository
    {
        Task<IEnumerable<ObtenerCategoriaPresupuestalPaginadoResponseDTO>> ObtenerCategoriaPresupuestalPaginado(ObtenerCategoriaPresupuestalPaginadoRequestDTO request);

        Task<ObtenerCategoriaPresupuestalResponseDTO> ObtenerCategoriaPresupuestal(ObtenerCategoriaPresupuestalRequestDTO request);

        Task<int> Guardar(CategoriaPresupuestal parametro);

        Task<int> Actualizar(CategoriaPresupuestal parametro);

        Task<int> ActualizarAEICategoria(CategoriaPresupuestal parametro);

        Task<ObtenerCodigoPresupuestalResponseDTO> ObtenerCodigoPresupuestal(ObtenerCodigoPresupuestalRequestDTO request);

        Task<IEnumerable<ObtenerListadoCategoriaPresupuestalResponseDTO>> ObtenerListadoCategoriaPresupuestal(ObtenerListadoCategoriaPresupuestalRequestDTO request);
    }
}
