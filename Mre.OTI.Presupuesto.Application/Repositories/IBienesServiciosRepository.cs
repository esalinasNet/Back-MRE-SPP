using Mre.OTI.Presupuesto.Application.DTO.BienesServicios;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IBienesServiciosRepository
    {
        Task<IEnumerable<ObtenerBienesServiciosPaginadoResponseDTO>> ObtenerBienesServiciosPaginado(ObtenerBienesServiciosPaginadoRequestDTO request);

        Task<int> Guardar(BienesServicios parametro);

        Task<int> Actualizar(BienesServicios parametro);

        Task<int> Eliminar(BienesServicios parametro);
                
        Task<ObtenerBienesServiciosResponseDTO> ObtenerBienesServicios(ObtenerBienesServiciosRequestDTO request);

        Task<IEnumerable<ObtenerListadoBienesServiciosResponseDTO>> ObtenerListadoBienesServicios(ObtenerListadoBienesServiciosRequestDTO request);

        Task<IEnumerable<ObtenerListadoBienesServiciosTipoItemsResponseDTO>> ObtenerListadoBienesServiciosTipoItems(ObtenerListadoBienesServiciosTipoItemsRequestDTO request);

        Task<IEnumerable<ObtenerListadoGrupoBienesServiciosResponseDTO>> ObtenerListadoGrupoBienesServicios(ObtenerListadoGrupoBienesServiciosRequestDTO request);

        Task<IEnumerable<ObtenerListadoBienesServiciosGrupoBienResponseDTO>> ObtenerListadoBienesServiciosGrupoBien(ObtenerListadoBienesServiciosGrupoBienRequestDTO request);
    }
}
