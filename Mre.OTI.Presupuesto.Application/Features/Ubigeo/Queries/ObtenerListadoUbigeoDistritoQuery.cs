using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerListadoUbigeoDistritoQuery : IRequestHandler<ObtenerListadoUbigeoDistritoViewModel, IEnumerable<ObtenerListadoUbigeoDistritoResponseViewModel>>
    {
        readonly private IUbigeoRepository _IUbigeoRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoUbigeoDistritoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUbigeoRepository IUbigeoRepository, IMapper mapper)
        {
            _IUbigeoRepository = IUbigeoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoUbigeoDistritoResponseViewModel>> Handle(ObtenerListadoUbigeoDistritoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = UbigeoMap.MaptoDistritoDTO(request);

                var result = await _IUbigeoRepository.ObtenerListadoUbigeoDistrito(dto);
                return result.Select(x => (ObtenerListadoUbigeoDistritoResponseViewModel)UbigeoMap.MaptoViewModelDistrito(x));

                // return _mapper.Map<ObtenerListadoUsuarioResponseViewModel>(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
