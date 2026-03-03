using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    public class ObtenerListadoUbigeoExteriorOseQuery : IRequestHandler<ObtenerListadoUbigeoExteriorOseViewModel, IEnumerable<ObtenerListadoUbigeoExteriorOseResponseViewModel>>
    {
        readonly private IUbigeoExteriorRepository _IUbigeoExteriorRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoUbigeoExteriorOseQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUbigeoExteriorRepository IUbigeoExteriorRepository, IMapper mapper)
        {
            _IUbigeoExteriorRepository = IUbigeoExteriorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoUbigeoExteriorOseResponseViewModel>> Handle(ObtenerListadoUbigeoExteriorOseViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = UbigeoExteriorMap.MaptoExteriorOseDTO(request);

                var result = await _IUbigeoExteriorRepository.ObtenerListadoUbigeoExteriorOse(dto);
                return result.Select(x => (ObtenerListadoUbigeoExteriorOseResponseViewModel)UbigeoExteriorMap.MaptoViewModelExteriorOse(x));

                // return _mapper.Map<ObtenerListadoUsuarioResponseViewModel>(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
