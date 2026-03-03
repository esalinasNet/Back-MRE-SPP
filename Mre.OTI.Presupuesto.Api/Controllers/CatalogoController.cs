
using AutoMapper.Internal;
using HEP.Seguridad.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Command;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries;
using Mre.OTI.Presupuesto.Application.Util;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/catalogo")]
    [ApiController]
    [Authorize] 
    [AuthorizeCheckActionFilter]
    public class CatalogoController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public CatalogoController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }

        [HttpGet]
        [Route("lista")]
     
        public async Task<IActionResult> ObtenerListaCatalogoPost([FromQuery] ObtenerListadoCatalogoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("obtenerpaginado")]
        public async Task<IActionResult> ObtenerCatalogoPaginado([FromQuery] ObtenerCatalogoPaginadoViewModel request)
        {
           
            var result = await _IMediator.Send(request);
            return Ok(result);

        }
        [HttpGet]
        [Route("obtener")]
        public async Task<IActionResult> ObtenerCatalogoPorID([FromQuery] ObtenerCatalogoViewModel request)
        {
            request.usuarioConsulta = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarCatalogoViewModel request)
        {

            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioCreacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        [Route("eliminar")]
        public async Task<IActionResult> Inactivar(EliminarCatalogoViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Actualizar(ActualizarCatalogoViewModel request)
        {
            request.ipModificacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioModificacion = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;

            var result = await _IMediator.Send(request);
            return Ok(result);
        }

        //[HttpPost("exportar")]
        //[ProducesResponseType(typeof(byte[]), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(JsonErrorResponse), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(JsonErrorResponse), (int)HttpStatusCode.InternalServerError)]
        //public async Task<IActionResult> Exportar([FromBody] ExportarMetasViewModel request)
        //{
        //    var result = await _IMediator.Send(request);
        //    return Ok(result);
        //}







    }
}
