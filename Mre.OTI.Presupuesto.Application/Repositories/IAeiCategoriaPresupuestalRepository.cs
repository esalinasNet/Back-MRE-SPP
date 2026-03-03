using Mre.OTI.Presupuesto.Application.DTO.AeiCategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.DTO.AeiCentroCostos;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IAeiCategoriaPresupuestalRepository
    {
        Task<IEnumerable<ObtenerAeiCategoriaPresupuestalResponseDTO>> ObtenerAeiCategoriaPresupuestal(ObtenerAeiCategoriaPresupuestalRequestDTO request);

        Task<int> Guardar(AeiCategoriaPresupuestal parametro);

        Task<int> Eliminar(AeiCategoriaPresupuestal parametro);
    }
}
