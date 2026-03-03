using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Queries;
using Mre.OTI.Presupuesto.Application.Features.FuenteFinanciamiento.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/fuentefinanciamiento")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class FuenteFinanciamientoController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public FuenteFinanciamientoController(IMediator IMediator)
        {
            _IMediator = IMediator; //Calendario
        }

        [HttpGet]
        [Route("listado")]
        public async Task<IActionResult> ObtenerListadoAcciones([FromQuery] ObtenerListadoFuenteFinanciamientoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
