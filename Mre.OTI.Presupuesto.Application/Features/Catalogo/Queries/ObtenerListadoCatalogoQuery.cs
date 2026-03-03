using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Catalogo;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries
{
    public class ObtenerListadoCatalogoQuery : IRequestHandler<ObtenerListadoCatalogoViewModel, IEnumerable<ObtenerListadoCatalogoResponseViewModel>>
    {
        readonly private ICatalogoRepository _ICatalogoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoCatalogoQuery(ICatalogoRepository ICatalogoRepository, IMapper mapper, IUsuarioRolRepository iUsuarioRolRepository)
        {
            _ICatalogoRepository = ICatalogoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = iUsuarioRolRepository; 
        }
        public async Task<IEnumerable<ObtenerListadoCatalogoResponseViewModel>> Handle(ObtenerListadoCatalogoViewModel request, CancellationToken cancellationToken)
        {
            var result = await _ICatalogoRepository.ObtenerListadoCatalogo();

            return result.Select(x => CatalogoMap.MaptoViewModel(x)).OrderBy(y=>y.nombreCatalogo);
            
        }
    }
}
