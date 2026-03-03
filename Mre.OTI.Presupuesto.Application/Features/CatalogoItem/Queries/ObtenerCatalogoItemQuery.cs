using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CatalogoItem.Queries
{
    public class ObtenerCatalogoItemQuery : IRequestHandler<ObtenerCatalogoItemViewModel, ObtenerCatalogoItemResponseViewModel>
    {
        readonly private ICatalogoItemRepository _ICatalogoItemRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerCatalogoItemQuery(ICatalogoItemRepository ICatalogoItemRepository, IUsuarioRolRepository IUsuarioRolRepository, IMapper mapper)
        {
            _ICatalogoItemRepository = ICatalogoItemRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
            _mapper = mapper;
        }
        public async Task<ObtenerCatalogoItemResponseViewModel> Handle(ObtenerCatalogoItemViewModel request, CancellationToken cancellationToken)
        {
           
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {  VariablesGlobales.TablaRol.ANALISTA_OGTH,
                   VariablesGlobales.TablaRol.AUXILIAR_OGTH });


                if (request.idCatalogoItem == 0) throw new MreException("ingrese idcatalogoitem");
                var result = await _ICatalogoItemRepository.ObtenerCatalogoItemsActivosXIdCatalogoItem(request.idCatalogoItem);

                return _mapper.Map<ObtenerCatalogoItemResponseViewModel>(result);
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
