using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    public class ObtenerListadoUbigeoExteriorRegionQuery : IRequestHandler<ObtenerListadoUbigeoExteriorRegionViewModel, IEnumerable<ObtenerListadoUbigeoExteriorRegionResponseViewModel>>
    {
        readonly private IUbigeoExteriorRepository _IUbigeoExteriorRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoUbigeoExteriorRegionQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUbigeoExteriorRepository IUbigeoExteriorRepository, IMapper mapper)
        {
            _IUbigeoExteriorRepository = IUbigeoExteriorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoUbigeoExteriorRegionResponseViewModel>> Handle(ObtenerListadoUbigeoExteriorRegionViewModel request, CancellationToken cancellationToken)
        {
            var result = await _IUbigeoExteriorRepository.ObtenerListadoUbigeoExteriorRergion();

            return result.Select(x => (ObtenerListadoUbigeoExteriorRegionResponseViewModel)UbigeoExteriorMap.MaptoViewModelRegion(x));
        }
    }
}
