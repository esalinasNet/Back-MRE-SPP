using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Cmn.Command;
using Mre.OTI.Presupuesto.Application.Features.Cmn.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/cmn")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class CmnController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public CmnController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        /// <summary>
        /// Obtener CMN paginado
        /// </summary>
        [HttpGet]
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerCmnPaginado([FromQuery] ObtenerCmnPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener listado de CMN sin paginación
        /// </summary>
        [HttpGet]
        [Route("listado")]
        public async Task<IActionResult> ObtenerListadoCmn([FromQuery] ObtenerListadoCmnViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Guardar nuevo CMN
        /// </summary>
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Agregar([FromBody] AgregarCmnViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualizar CMN existente
        /// </summary>
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarCmnViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Eliminar CMN (soft delete)
        /// </summary>
        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] EliminarCmnViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener CMN por ID
        /// </summary>
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerCmnPorId([FromQuery] ObtenerCmnPorIdViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
