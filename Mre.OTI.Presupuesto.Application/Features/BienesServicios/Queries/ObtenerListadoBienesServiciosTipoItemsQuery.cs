using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.BienesServicios;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.BienesServicios.Queries
{
    public class ObtenerListadoBienesServiciosTipoItemsQuery : IRequestHandler<ObtenerListadoBienesServiciosTipoItemsViewModel, IEnumerable<ObtenerListadoBienesServiciosTipoItemsResponseViewModel>>
    {
        private readonly IBienesServiciosRepository _IBienesServiciosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoBienesServiciosTipoItemsQuery(IUsuarioRolRepository IUsuarioRolRepository, IBienesServiciosRepository IBienesServiciosRepository, IMapper mapper)
        {
            _IBienesServiciosRepository = IBienesServiciosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoBienesServiciosTipoItemsResponseViewModel>> Handle(ObtenerListadoBienesServiciosTipoItemsViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = BienesServiciosMap.MaptoBienesServiciosTipoItemsDTO(request);

                var result = await _IBienesServiciosRepository.ObtenerListadoBienesServiciosTipoItems(dto);

                return result.Select(x => (ObtenerListadoBienesServiciosTipoItemsResponseViewModel)BienesServiciosMap.MaptoViewModelTipoItems(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }    
    }
}
