using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionAnios.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/programacionanios")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class ProgramacionAniosController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public ProgramacionAniosController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        /// <summary>
        /// Copiar programación de años
        /// </summary>
        [HttpPost]
        [Route("copiar")]
        public async Task<IActionResult> CopiarProgramacion([FromBody] CopiarProgramacionAniosViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() :
                    Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}