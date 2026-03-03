using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.FasesPoi;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.FasesPoi.Queries
{
    public class ObtenerListadoFasesPoiQuery : IRequestHandler<ObtenerListadoFasesPoiViewModel, IEnumerable<ObtenerListadoFasesPoiResponseViewModel>>
    {
        readonly private IFasesPoiRepository _IFasesPoiRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoFasesPoiQuery(IUsuarioRolRepository IIUsuarioRolRepository, IFasesPoiRepository IFasesPoiRepository, IMapper mapper)
        {
            _IFasesPoiRepository = IFasesPoiRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoFasesPoiResponseViewModel>> Handle(ObtenerListadoFasesPoiViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = FasesPoiMap.MaptoFasesPoiDTO(request);

                var result = await _IFasesPoiRepository.ObtenerListadoFasesPoi(dto);

                return result.Select(x => (ObtenerListadoFasesPoiResponseViewModel)FasesPoiMap.MaptoViewModelFasesPoi(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
