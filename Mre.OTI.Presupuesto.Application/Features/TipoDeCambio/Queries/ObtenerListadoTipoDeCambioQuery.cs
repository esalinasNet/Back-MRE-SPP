using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries
{
    public class ObtenerListadoTipoDeCambioQuery : IRequestHandler<ObtenerListadoTipodeCambioViewModel, IEnumerable<ObtenerListadoTipoDeCambioResponseViewModel>>
    {
        readonly private ITipoDeCambioRepository _ITipoDeCambioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoTipoDeCambioQuery(IUsuarioRolRepository IIUsuarioRolRepository, ITipoDeCambioRepository ITipoDeCambioRepository, IMapper mapper)
        {
            _ITipoDeCambioRepository = ITipoDeCambioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoTipoDeCambioResponseViewModel>> Handle(ObtenerListadoTipodeCambioViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = TipoDeCambioMap.MaptoTipoDeCambioDTO(request);

                var result = await _ITipoDeCambioRepository.ObtenerListadoTipoDeCambio(dto);

                return result.Select(x => (ObtenerListadoTipoDeCambioResponseViewModel)TipoDeCambioMap.MaptoViewModelTipoDeCambio(x));
                                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
