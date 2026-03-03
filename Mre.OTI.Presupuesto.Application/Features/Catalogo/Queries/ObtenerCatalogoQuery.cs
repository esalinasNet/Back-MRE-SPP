using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Catalogo;
using Mre.OTI.Presupuesto.Application.Util;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries
{
    public class ObtenerCatalogoQuery : IRequestHandler<ObtenerCatalogoViewModel, ObtenerCatalogoResponseViewModel>
    {
        readonly private ICatalogoRepository _ICatalogoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerCatalogoQuery(ICatalogoRepository ICatalogoRepository, IMapper mapper, IUsuarioRolRepository iUsuarioRolRepository            )
        {
            _ICatalogoRepository = ICatalogoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = iUsuarioRolRepository; 
        }
        public async Task<ObtenerCatalogoResponseViewModel> Handle(ObtenerCatalogoViewModel request, CancellationToken cancellationToken)
        {  

            if (request.idCatalogo == 0) throw new MreException("ingrese idcatalogo");
            var result = await _ICatalogoRepository.ObtenerCatalogo(request.idCatalogo);

            return _mapper.Map<ObtenerCatalogoResponseViewModel>(result);

        }
    }
}
