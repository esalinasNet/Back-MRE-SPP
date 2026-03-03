using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.BienesServicios;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.BienesServicios.Queries
{
    public class ObtenerListadoBienesServiciosQuery : IRequestHandler<ObtenerListadoBienesServiciosViewModel, IEnumerable<ObtenerListadoBienesServiciosResponseViewModel>>
    {
        private readonly IBienesServiciosRepository _IBienesServiciosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoBienesServiciosQuery(IUsuarioRolRepository IUsuarioRolRepository, IBienesServiciosRepository IBienesServiciosRepository, IMapper mapper)
        {
            _IBienesServiciosRepository = IBienesServiciosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoBienesServiciosResponseViewModel>> Handle(ObtenerListadoBienesServiciosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = BienesServiciosMap.MaptoBienesServiciosDTO(request);

                var result = await _IBienesServiciosRepository.ObtenerListadoBienesServicios(dto);

                return result.Select(x => (ObtenerListadoBienesServiciosResponseViewModel)BienesServiciosMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}