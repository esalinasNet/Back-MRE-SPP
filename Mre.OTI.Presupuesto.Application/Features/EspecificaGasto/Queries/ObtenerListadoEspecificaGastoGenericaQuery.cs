using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries
{
    public class ObtenerListadoEspecificaGastoGenericaQuery : IRequestHandler<ObtenerListadoEspecificaGastoGenericaViewModel, IEnumerable<ObtenerListadoEspecificaGastoGenericaResponseViewModel>>
    {
        private readonly IEspecificaGastoRepository _IEspecificaGastoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoEspecificaGastoGenericaQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEspecificaGastoRepository IEspecificaGastoRepository,
            IMapper mapper)
        {
            _IEspecificaGastoRepository = IEspecificaGastoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoEspecificaGastoGenericaResponseViewModel>> Handle(ObtenerListadoEspecificaGastoGenericaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = EspecificaGastoMap.MaptoProgramacionEspecificaGenericaDTO(request);


                var result = await _IEspecificaGastoRepository.ObtenerListadoEspecificaGastoGenerica(dto);

                return result.Select(x => (ObtenerListadoEspecificaGastoGenericaResponseViewModel)EspecificaGastoMap.MaptoViewModelGenerica(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
