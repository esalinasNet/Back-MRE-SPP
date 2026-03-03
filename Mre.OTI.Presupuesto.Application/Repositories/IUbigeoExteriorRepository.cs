using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.DTO.UbigeoExterior;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IUbigeoExteriorRepository
    {
        Task<IEnumerable<ObtenerUbigeoExteriorPaginadoResponseDTO>> ObtenerUbigeoExteriorPaginado(ObtenerUbigeoExteriorPaginadoRequestDTO request);

        Task<int> GuardarUbigeoExterior(UbigeoExterior parametro);

        Task<int> ActualizarUbigeoExterior(UbigeoExterior parametro);
        Task<int> EliminarUbigeoExterior(UbigeoExterior parametro);

        Task<ObtenerUbigeoExteriorResponseDTO> ObtenerUbigeoExterior(int idUbigeoExterior);

        Task<IEnumerable<ObtenerListadoUbigeoExteriorRegionResponseDTO>> ObtenerListadoUbigeoExteriorRergion();

        Task<IEnumerable<ObtenerListadoUbigeoExteriorPaisResponseDTO>> ObtenerListadoUbigeoExteriorPais(ObtenerListadoUbigeoExteriorPaisRequestDTO request);

        Task<IEnumerable<ObtenerListadoUbigeoExteriorOseResponseDTO>> ObtenerListadoUbigeoExteriorOse(ObtenerListadoUbigeoExteriorOseRequestDTO request);
    }
}
