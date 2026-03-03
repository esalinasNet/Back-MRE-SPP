
using AutoMapper.Internal;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mre.OTI.Presupuesto.Application.Features.Autenticacion.Command;
using Mre.OTI.Presupuesto.Application.Features.LogSession.Command;
using Mre.OTI.Presupuesto.Application.Features.Seguridad.Queries;
using Mre.OTI.Presupuesto.Application.Features.Usuario.Command;
using Mre.OTI.Presupuesto.Application.Util;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/passport")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly IMediator _IMediator;
        public AutenticarController(IMediator IMediator)
        {
            _IMediator = IMediator;
        }



        [HttpPost]
        public async Task<IActionResult> autenticar(AutenticarUsuarioViewModel request)
        {
            request.ipAcceso = HttpContext.Connection.RemoteIpAddress.ToString();
            request.dispositivo = Request.Headers.ContainsKey("User-Agent") ? Request.Headers.GetOrDefault("User-Agent").ToString() : string.Empty;
            var result = await _IMediator.Send(request);
            return Ok(result);

        }
 

        [HttpGet]
        [Authorize()]
        [Route("validateToken")]
        public async Task<IActionResult> verificarSession([FromQuery] ValidarAutenticarUsuarioViewModel request)
        {

            var result = await _IMediator.Send(request);
            return Ok(result);
        }



        [HttpPost]
        [Route("logoutExterior")]
        public async Task<IActionResult> logoutLogExterior(AgregarLogSessionExteriorViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioLogout = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.token = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUTORIZATION_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUTORIZATION_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.dispositivo = Request.Headers.ContainsKey("User-Agent") ? Request.Headers.GetOrDefault("User-Agent").ToString() : string.Empty;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }


        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> logoutLog(AgregarLogSessionViewModel request)
        {
            request.ipCreacion = HttpContext.Connection.RemoteIpAddress.ToString();
            request.usuarioLogout = Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUDITORIA_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUDITORIA_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.token=Request.Headers.ContainsKey(Constantes.SISTEMA.VAR_AUTORIZATION_HEADER) ? Request.Headers.GetOrDefault(Constantes.SISTEMA.VAR_AUTORIZATION_HEADER).ToString() : Constantes.SISTEMA.VAR_VAL_ZERO_ENCRYPT;
            request.dispositivo = Request.Headers.ContainsKey("User-Agent") ? Request.Headers.GetOrDefault("User-Agent").ToString() : string.Empty;
            var result = await _IMediator.Send(request);
            return Ok(result);
        }


        [HttpPost]
        [Route("autorizacion")]
        // [Authorize()]
        public async Task<IActionResult> ObtenerAutorizacionInfo( ObtenerAutorizacionInfoViewModel request)
        {
            var result = await _IMediator.Send(request);
            return Ok(result);

        }
    }
}
