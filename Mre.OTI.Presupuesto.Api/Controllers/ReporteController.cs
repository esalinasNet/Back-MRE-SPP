using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Reporte.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/reporte")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class ReporteController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public ReporteController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        /// <summary>
        /// Obtener reporte de actividad con tareas y acciones
        /// </summary>
        [HttpGet]
        [Route("obtener-actividad")]
        public async Task<IActionResult> ObtenerReporteActividad([FromQuery] ObtenerReporteActividadViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}