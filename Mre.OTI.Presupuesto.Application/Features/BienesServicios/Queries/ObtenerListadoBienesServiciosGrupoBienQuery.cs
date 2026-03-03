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
    public class ObtenerListadoBienesServiciosGrupoBienQuery : IRequestHandler<ObtenerListadoBienesServiciosGrupoBienViewModel, IEnumerable<ObtenerListadoBienesServiciosGrupoBienResponseViewModel>>
    {
        private readonly IBienesServiciosRepository _IBienesServiciosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoBienesServiciosGrupoBienQuery(IUsuarioRolRepository IUsuarioRolRepository, IBienesServiciosRepository IBienesServiciosRepository, IMapper mapper)
        {
            _IBienesServiciosRepository = IBienesServiciosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoBienesServiciosGrupoBienResponseViewModel>> Handle(ObtenerListadoBienesServiciosGrupoBienViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = BienesServiciosMap.MaptoBienesServiciosGrupoBienDTO(request);

                var result = await _IBienesServiciosRepository.ObtenerListadoBienesServiciosGrupoBien(dto);

                return result.Select(x => (ObtenerListadoBienesServiciosGrupoBienResponseViewModel)BienesServiciosMap.MaptoGrupoBienViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
