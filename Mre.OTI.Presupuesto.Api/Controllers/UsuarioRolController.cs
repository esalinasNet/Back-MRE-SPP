
using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Command;
using Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/usuariorol")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class UsuarioRolController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public UsuarioRolController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        [HttpGet]
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerUsuarioRolPaginado([FromQuery] ObtenerUsuarioRolPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerUsuarioRol([FromQuery] ObtenerUsuarioRolViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> guardar( AgregarUsuarioRolViewModel request)
        {
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> eliminar(EliminarUsuarioRolViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> actualizar(ActualizarUsuarioRolViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

    }
}
