using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.ReporteFinanciero.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/reportefinanciero")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class ReporteFinancieroController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public ReporteFinancieroController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerReporteFinanciero([FromQuery] ObtenerReporteFinancieroViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER)
                ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString()
                : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}