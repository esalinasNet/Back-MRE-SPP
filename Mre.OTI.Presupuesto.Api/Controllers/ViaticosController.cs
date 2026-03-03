using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Viaticos.Command;
using Mre.OTI.Presupuesto.Application.Features.Viaticos.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/viaticos")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class ViaticosController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public ViaticosController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        /// <summary>
        /// Obtener Viáticos paginado
        /// </summary>
        [HttpGet]
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerViaticoPaginado([FromQuery] ObtenerViaticoPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener listado de Viáticos sin paginación
        /// </summary>
        [HttpGet]
        [Route("listado")]
        public async Task<IActionResult> ObtenerListadoViaticos([FromQuery] ObtenerListadoViaticosViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Guardar nuevo Viático
        /// </summary>
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Agregar([FromBody] AgregarViaticosViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualizar Viático existente
        /// </summary>
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViaticosViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Eliminar Viático (soft delete)
        /// </summary>
        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] EliminarViaticosViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener Viático por ID
        /// </summary>
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerViaticoPorId([FromQuery] ObtenerViaticoPorIdViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
