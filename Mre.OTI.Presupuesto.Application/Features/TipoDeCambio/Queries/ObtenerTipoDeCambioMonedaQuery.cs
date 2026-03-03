using AutoMapper;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries
{
    public class ObtenerTipoDeCambioMonedaQuery : IRequestHandler<ObtenerTipodeCambioMonedaViewModel, IEnumerable<ObtenerTipoDeCambioMonedaResponseViewModel>>
    {
        readonly private ITipoDeCambioRepository _ITipoDeCambioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerTipoDeCambioMonedaQuery(IUsuarioRolRepository IIUsuarioRolRepository, ITipoDeCambioRepository ITipoDeCambioRepository, IMapper mapper)
        {
            _ITipoDeCambioRepository = ITipoDeCambioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerTipoDeCambioMonedaResponseViewModel>> Handle(ObtenerTipodeCambioMonedaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = TipoDeCambioMap.MaptoTipoDeCambioMonedaDTO(request);

                var result = await _ITipoDeCambioRepository.ObtenerListadoTipoDeCambioMoneda(dto);

                return result.Select(x => (ObtenerTipoDeCambioMonedaResponseViewModel)TipoDeCambioMap.MaptoViewModelTipoDeCambioMoneda(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
