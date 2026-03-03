using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Command;
using Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries;
 
using Mre.OTI.Presupuesto.Application.Util;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/catalogoitem")]
    [ApiController]
    [Authorize]
    [AuthorizeCheckActionFilter]
    public class CatalogoItemController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public CatalogoItemController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }
        [HttpGet]
        [Route("obtenertipodocumento")]
        public async Task<IActionResult> ObtenerTipoDocumento([FromQuery] ObtenerTipoDocumentoIdentidadViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }        

        [HttpGet]
        [Route("obteneranios")]
        public async Task<IActionResult> ObtenerAnios([FromQuery] ObtenerAnioViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

       
        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> guardar([FromBody] AgregarCatalogoItemViewModel request)
        {
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> actualizar([FromBody] ActualizarCatalogoItemViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> eliminar([FromBody] EliminarCatalogoItemViewModel request)
        {
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpGet]

        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerCatalogoItemPaginado([FromQuery] ObtenerCatalogoItemPaginadoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerCatalogoItemsActivosXIdCatalogoItem([FromQuery] ObtenerCatalogoItemViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
       
        [HttpGet]
        [Route("obtenerestadocivil")]
        public async Task<IActionResult> ObtenerCatologoEstadoCivil([FromQuery] ObtenerEstadoCivilViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("obtenertipogenero")]
        public async Task<IActionResult> ObtenerCatologoTipoGenero([FromQuery] ObtenerTipoGeneroViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

    }
}
