using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries
{
    public class ObtenerTipoGeneroQuery : IRequestHandler<ObtenerTipoGeneroViewModel, IEnumerable<CatalogoItemViewModel>>
    {
        readonly private ICatalogoItemRepository _ICatalogoItemRepository;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerTipoGeneroQuery(ICatalogoItemRepository ICatalogoItemRepository, IUsuarioRolRepository IUsuarioRolRepository)
        {
            _ICatalogoItemRepository = ICatalogoItemRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<IEnumerable<CatalogoItemViewModel>> Handle(ObtenerTipoGeneroViewModel request, CancellationToken cancellationToken)
        {
            var result = await _ICatalogoItemRepository.ObtenerCatalogoItemsXCodigoCatalogo((int)VariablesGlobales.TablaCatalogo.TIPO_GENERO);

            return result.Select(x => (CatalogoItemViewModel)CatalogoItemMap.MaptoViewModel(x));
        }
    }
}
