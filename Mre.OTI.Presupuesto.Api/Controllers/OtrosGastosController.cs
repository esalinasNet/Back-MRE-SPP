using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Command;
using Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/otrosgastos")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class OtrosGastosController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public OtrosGastosController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        /// <summary>
        /// Obtener Otros Gastos paginado
        /// </summary>
        [HttpGet]
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerOtrosGastosPaginado([FromQuery] ObtenerOtrosGastosPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener listado de Otros Gastos sin paginación
        /// </summary>
        [HttpGet]
        [Route("listado")]
        public async Task<IActionResult> ObtenerListadoOtrosGastos([FromQuery] ObtenerListadoOtrosGastosViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Guardar nuevo registro de Otros Gastos
        /// </summary>
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Agregar([FromBody] AgregarOtrosGastosViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Actualizar registro de Otros Gastos existente
        /// </summary>
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarOtrosGastosViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Eliminar registro de Otros Gastos (soft delete)
        /// </summary>
        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] EliminarOtrosGastosViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Obtener registro de Otros Gastos por ID
        /// </summary>
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerOtrosGastosPorId([FromQuery] ObtenerOtrosGastosPorIdViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
