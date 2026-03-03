using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using System.Linq;
using Mre.OTI.Presupuesto.Application.Mapper;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries
{
    public class ObtenerAnioQuery : IRequestHandler<ObtenerAnioViewModel, IEnumerable<CatalogoItemViewModel>>
    {
        readonly private ICatalogoItemRepository _ICatalogoItemRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAnioQuery(ICatalogoItemRepository ICatalogoItemRepository, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _ICatalogoItemRepository = ICatalogoItemRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<IEnumerable<CatalogoItemViewModel>> Handle(ObtenerAnioViewModel request, CancellationToken cancellationToken)
        {
             


            var result = await _ICatalogoItemRepository.ObtenerCatalogoItemsXCodigoCatalogo((int)VariablesGlobales.TablaCatalogo.ANIOS);

            return result.Select(x => (CatalogoItemViewModel)CatalogoItemMap.MaptoViewModel(x));

        }
    }
}
