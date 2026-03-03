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
    public class ObtenerListadoGrupoBienesServiciosQuery : IRequestHandler<ObtenerListadoGrupoBienesServiciosViewModel, IEnumerable<ObtenerListadoGrupoBienesServiciosResponseViewModel>>
    {
        private readonly IBienesServiciosRepository _IBienesServiciosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoGrupoBienesServiciosQuery(IUsuarioRolRepository IUsuarioRolRepository, IBienesServiciosRepository IBienesServiciosRepository, IMapper mapper)
        {
            _IBienesServiciosRepository = IBienesServiciosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoGrupoBienesServiciosResponseViewModel>> Handle(ObtenerListadoGrupoBienesServiciosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = BienesServiciosMap.MaptoGrupoBienesServiciosDTO(request);

                var result = await _IBienesServiciosRepository.ObtenerListadoGrupoBienesServicios(dto);

                return result.Select(x => (ObtenerListadoGrupoBienesServiciosResponseViewModel)BienesServiciosMap.MaptoGrupoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
