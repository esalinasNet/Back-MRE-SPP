using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.OtrosGastosDetalle.Command;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/otros-gastos-detalle")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class OtrosGastosDetalleController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public OtrosGastosDetalleController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        /// <summary>
        /// Guardar o actualizar detalle de Otros Gastos
        /// </summary>
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> Guardar([FromBody] AgregarOtrosGastosDetalleViewModel request)
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