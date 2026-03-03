using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.DTO.Catalogo;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Catalogo;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries
{
    public class ObtenerCatalogoPaginadoQuery : IRequestHandler<ObtenerCatalogoPaginadoViewModel, dtCatalogoPaginadoResponseViewModel>
    {
        readonly private ICatalogoRepository _ICatalogoRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        private readonly IMapper _mapper;

        public ObtenerCatalogoPaginadoQuery(ICatalogoRepository ICatalogoRepository, IUsuarioRolRepository IIUsuarioRolRepository, IMapper mapper)
        {
            _ICatalogoRepository = ICatalogoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtCatalogoPaginadoResponseViewModel> Handle(ObtenerCatalogoPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = CatalogoMap.MaptoDTO(request);
            var result = await _ICatalogoRepository.ObtenerCatalogoPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var resultMapp = result.Select(x => CatalogoMap.MaptoDTO(x));

            var datos = _mapper.Map<IEnumerable<ObtenerCatalogoPaginadoResponseViewModel>>(resultMapp);

            dtCatalogoPaginadoResponseViewModel data = new dtCatalogoPaginadoResponseViewModel
            {
                draw = 1, //request.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = datos
            };

            return data;

        }
    }
}
