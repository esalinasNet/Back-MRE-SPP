using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Util;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries
{
    public class ObtenerCatalogoItemPaginadoQuery : IRequestHandler<ObtenerCatalogoItemPaginadoViewModel, dtCatalogoItemPaginadoResponseViewModel>
    {
        readonly private ICatalogoItemRepository _ICatalogoItemRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        private readonly IMapper _mapper;

        public ObtenerCatalogoItemPaginadoQuery(ICatalogoItemRepository ICatalogoRepository, IMapper mapper, IUsuarioRolRepository iUsuarioRolRepository)
        {
            _ICatalogoItemRepository = ICatalogoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = iUsuarioRolRepository;
        }
        public async Task<dtCatalogoItemPaginadoResponseViewModel> Handle(ObtenerCatalogoItemPaginadoViewModel request, CancellationToken cancellationToken)
        {
            
            var dto = CatalogoItemMap.MaptoDTO(request);


            //if (request.idCatalogo == 0) throw new MreException("Id catalogo es requerido");
            //if (request.paginaActual == 0) throw new MreException("ingrese paginaActual");
            //if (request.tamanioPagina == 0) throw new MreException("tamanioPagina anio");

            var result = await _ICatalogoItemRepository.ObtenerCatalogoItemPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var resultMapp = result.Select(x => CatalogoItemMap.MaptoDTO(x));

            var datos = _mapper.Map<IEnumerable<ObtenerCatalogoItemPaginadoResponseViewModel>>(resultMapp);

            dtCatalogoItemPaginadoResponseViewModel data = new dtCatalogoItemPaginadoResponseViewModel
            {
                draw = request.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = datos
            };

            return data;




        }
    }
}
