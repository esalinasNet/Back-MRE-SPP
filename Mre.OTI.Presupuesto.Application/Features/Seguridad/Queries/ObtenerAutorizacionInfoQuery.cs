using AutoMapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;

namespace Mre.OTI.Presupuesto.Application.Features.Seguridad.Queries
{
    public class ObtenerAutorizacionInfoQuery : IRequestHandler<ObtenerAutorizacionInfoViewModel, ObtenerAutozacionInfoResponseViewModel>
    {
        readonly private ISeguridadRepository _seguridadRepository;
        private readonly IMapper _mapper;

        public ObtenerAutorizacionInfoQuery(ISeguridadRepository seguridadRepository, IMapper mapper)
        {
            _mapper = mapper;
            _seguridadRepository = seguridadRepository;
        }

        public async Task<ObtenerAutozacionInfoResponseViewModel> Handle(ObtenerAutorizacionInfoViewModel request, CancellationToken cancellationToken)
        {
            try
            {


                // var idSistema = Convert.ToInt32(UrlEncryptationSecurity.Decrypt(request.IdSistema));
                //  var idPerfil = Convert.ToInt32(UrlEncryptationSecurity.Decrypt(request.IdPerfil));

                 var codigoSistema = request.IdSistema;
                  var idPerfil = Convert.ToInt32(request.IdPerfil);


                var opciones = await _seguridadRepository.ObtenerOpcion(codigoSistema, idPerfil);
                var perfilOpcion = await _seguridadRepository.ObtenerPerfilOpcion(codigoSistema, idPerfil);

                var menus = opciones.Select(x => new OpcionViewModel
                {
                    IdOpcion = x.ID_OPCION,
                    IdOpcionPadre = x.ID_OPCION_PADRE,
                    Nombre = x.NOMBRE,
                    Url = x.URL
                }).ToList();

                var permisos = perfilOpcion.Select(x => new PermisoViewModel
                {
                    IdOpcion = x.ID_OPCION,
                    IdPerfil = x.ID_PERFIL,
                    Accion = x.ACCION
                }).ToList();

                var result = new ObtenerAutozacionInfoResponseViewModel
                {
                    Opciones = menus,
                    Permisos = permisos,
                    message = "OK",
                    result = true
                };

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
      


    }
}
