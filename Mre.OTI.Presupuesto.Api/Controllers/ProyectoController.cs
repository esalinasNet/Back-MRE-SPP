using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Proyecto.Queries;
using Mre.OTI.Presupuesto.Application.Features.Proyecto.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/proyecto")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class ProyectoController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public ProyectoController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        /// <summary>
        /// Obtener Proyecto paginado
        /// </summary>
        [HttpGet]
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerProyectoPaginado([FromQuery] ObtenerProyectoPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener listado de Proyecto sin paginación
        /// </summary>
        [HttpGet]
        [Route("listado")]
        public async Task<IActionResult> ObtenerListadoProyecto([FromQuery] ObtenerListadoProyectoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Guardar nuevo Proyecto
        /// </summary>
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Agregar([FromBody] AgregarProyectoViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualizar Proyecto existente
        /// </summary>
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarProyectoViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Eliminar Proyecto (soft delete)
        /// </summary>
        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] EliminarProyectoViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener Proyecto por ID
        /// </summary>
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerProyectoPorId([FromQuery] ObtenerProyectoPorIdViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}