
using AutoMapper.Internal;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Usuario.Command;
using Mre.OTI.Presupuesto.Application.Features.Usuario.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;
using HEP.Seguridad.Api.Filters;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/usuario")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public UsuarioController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        [HttpGet]
        [Route("obtenerpaginado")]
      //  [AuthorizeCheckActionFilter]
        public async Task<IActionResult> ObtenerObjetivoSectorialPost([FromQuery] ObtenerUsuarioPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerUsuarioPorID([FromQuery] ObtenerUsuarioViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("listadousuario")]
      //  [AuthorizeCheckActionFilter]
        public async Task<IActionResult> ObtenerListadoUsuario([FromQuery] ObtenerListadoUsuarioViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("listadousuarioselect")]
        //  [AuthorizeCheckActionFilter]
        public async Task<IActionResult> listadousuarioselect([FromQuery] ObtenerListadoUsuarioSelectViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarUsuarioViewModel request)
        {
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> Inactivar(EliminarUsuarioViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Actualizar(ActualizarUsuarioViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("listarusuarios")]
        //  [AuthorizeCheckActionFilter]
        public async Task<IActionResult> ListarUsuarios([FromQuery] ObtenerListarUsuariosViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

    }
}
