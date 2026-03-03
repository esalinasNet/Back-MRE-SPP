using Mre.OTI.Presupuesto.Application.DTO.Funcion;
using Mre.OTI.Presupuesto.Application.DTO.Ubigeo;
using Mre.OTI.Presupuesto.Application.DTO.Usuario;
using Mre.OTI.Presupuesto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface IUbigeoRepository
    {
        Task<IEnumerable<ObtenerUbigeoPaginadoResponseDTO>> ObtenerUbigeoPaginado(ObtenerUbigeoPaginadoRequestDTO request);

        Task<IEnumerable<ObtenerListadoUbigeoDepartamentoResponseDTO>> ObtenerListadoUbigeoDepartamento();

        Task<IEnumerable<ObtenerListadoUbigeoProvinciaResponseDTO>> ObtenerListadoUbigeoProvincia(ObtenerListadoUbigeoProvinciaRequestDTO request);

        Task<IEnumerable<ObtenerListadoUbigeoDistritoResponseDTO>> ObtenerListadoUbigeoDistrito(ObtenerListadoUbigeoDistritoRequestDTO request);

        Task<int> GuardarUbigeoDepartamento(Ubigeo parametro);

        Task<int> GuardarUbigeoProvincia(Ubigeo parametro);

        Task<int> GuardarUbigeoDistrito(Ubigeo parametro);

        Task<ObtenerDepartamentoResponseDTO> ObtenerUbigeoDepartamento(string ubigeo);
        Task<ObtenerProvinciaResponseDTO> ObtenerUbigeoProvincia(string ubigeo);
        Task<ObtenerDistritoResponseDTO> ObtenerUbigeoDistrito(string ubigeo);


        Task<int> ActualizarDepartamento(Ubigeo parametro);
        Task<int> ActualizarProvincia(Ubigeo parametro);
        Task<int> ActualizarDistrito(Ubigeo parametro);
    }
}
