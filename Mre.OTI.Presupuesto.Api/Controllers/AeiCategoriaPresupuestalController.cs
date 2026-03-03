using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Command;
using Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Queries;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Command;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/aeicategoriapresupuestal")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class AeiCategoriaPresupuestalController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public AeiCategoriaPresupuestalController(IMediator IMediator)    
        {
            _IMediator = IMediator;
        }

        [HttpGet]                             
        [Route("obteneraeicategoria")]
        public async Task<IActionResult> ObtenerAeiCategoriaPresupuestal([FromQuery] ObtenerAeiCategoriaPresupuestalViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPost]                               
        [Route("guardar")]
        public async Task<IActionResult> agregar([FromBody] AgregarAeiCategoriaPresupuestalViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPut]                           //AeiCategoriaPresupuestal    EliminarAeiCategoriaPresupuestalViewModel
        [Route("eliminar")]
        public async Task<IActionResult> eliminar([FromBody] EliminarAeiCategoriaPresupuestalViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
