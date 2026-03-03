using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Command;
using Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Command;
using Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/categoriapresupuestal")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class CategoriaPresupuestalController : ControllerBase
    {

        private readonly IMediator _IMediator;
        public CategoriaPresupuestalController(IMediator IMediator)
        {
            _IMediator = IMediator; //Calendario
        }

        [HttpGet]                                
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerCategoriaPresupuestalPaginado([FromQuery] ObtenerCategoriaPresupuestalPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        
        [HttpGet]                              
        [Route("obtener")]
        public async Task<IActionResult> ObtenerCategoriaPresupuestal([FromQuery] ObtenerCategoriaPresupuestalViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPost]                              
        [Route("guardar")]
        public async Task<IActionResult> agregar([FromBody] AgregarCategoriaPresupuestalViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPut]                                  
        [Route("actualizar")]
        public async Task<IActionResult> actualizar([FromBody] ActualizarCategoriaPresupuestalViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPut]                                    
        [Route("actualizaraeicategoria")]
        public async Task<IActionResult> ActualizarAEICategoria([FromBody] ActualizarAeiCategoriaPresupuestalViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]                                       // CategoriaPresupuestal    ObtenerCodigoPresupuestalResponseDTO
        [Route("obtenercodigopresupuestal")]
        public async Task<IActionResult> ObtenerCodigoPresupuestal([FromQuery] ObtenerCodigoPresupuestalViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]                                   //CategoriaPresupuestal ObtenerListadoCategoriaPresupuestalResponseViewModel
        [Route("listado")] 
        public async Task<IActionResult> ObtenerListadoCategoriaPresupuestal([FromQuery] ObtenerListadoCategoriaPresupuestalViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ?
                    Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
    }
}
