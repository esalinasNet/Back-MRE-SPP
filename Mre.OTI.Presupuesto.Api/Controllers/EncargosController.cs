using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Encargos.Command;
using Mre.OTI.Presupuesto.Application.Features.Encargos.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/encargos")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class EncargosController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public EncargosController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        /// <summary>
        /// Obtener Encargos paginado
        /// </summary>
        [HttpGet]
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerEncargosPaginado([FromQuery] ObtenerEncargosPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener listado de Encargos sin paginación
        /// </summary>
        [HttpGet]
        [Route("listado")]
        public async Task<IActionResult> ObtenerListadoEncargos([FromQuery] ObtenerListadoEncargosViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Guardar nuevo registro de Encargos
        /// </summary>
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Agregar([FromBody] AgregarEncargosViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualizar registro de Encargos existente
        /// </summary>
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarEncargosViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Eliminar registro de Encargos (soft delete)
        /// </summary>
        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] EliminarEncargosViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener registro de Encargos por ID
        /// </summary>
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerEncargosPorId([FromQuery] ObtenerEncargosPorIdViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
