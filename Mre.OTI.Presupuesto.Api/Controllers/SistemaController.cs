using AutoMapper.Internal;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Sistema.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/sistema")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public SistemaController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        [HttpGet]
        [Route("listarsistemas")]
        public async Task<IActionResult> ObtenerListadoSistema([FromQuery] ObtenerListadoSistemaViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
