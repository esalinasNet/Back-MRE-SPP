using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Command;
using Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{    
    [Route("v1/rree/spp/presupuesto/seg/aprobacionescostos")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class AprobacionesCostosController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public AprobacionesCostosController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        [HttpGet]
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerAprobacionesCostosPaginado([FromQuery] ObtenerAprobacionesCostosPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerAprobacionesCostos([FromQuery] ObtenerAprobacionesCostosViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> agregar([FromBody] AgregarAprobacionesCostosViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> actualizar([FromBody] ActualizarAprobacionesCostosViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> eliminar([FromBody] EliminarAprobacionesCostosViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("obtenerAprobacionesCentroCostos")]
        public async Task<IActionResult> ObtenerCodigoAprobacionesCostos([FromQuery] ObtenerAprobacionesCentroCostosViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("listado")]
        public async Task<IActionResult> ObtenerListadoAprobacionesCostos([FromQuery] ObtenerListadoAprobacionesCostosViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
