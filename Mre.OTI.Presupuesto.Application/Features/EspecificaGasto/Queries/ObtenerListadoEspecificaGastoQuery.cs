using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Util;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries
{
    internal class ObtenerListadoEspecificaGastoQuery : IRequestHandler<ObtenerListadoEspecificaGastoViewModel, IEnumerable<ObtenerListadoEspecificaGastoResponseViewModel>>
    {
        private readonly IEspecificaGastoRepository _IEspecificaGastoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoEspecificaGastoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEspecificaGastoRepository IEspecificaGastoRepository,
            IMapper mapper)
        {
            _IEspecificaGastoRepository = IEspecificaGastoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoEspecificaGastoResponseViewModel>> Handle(ObtenerListadoEspecificaGastoViewModel request, CancellationToken cancellationToken)
        { 
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = EspecificaGastoMap.MaptoProgramacionEspecificaDTO(request);

                
                var result = await _IEspecificaGastoRepository.ObtenerListadoEspecificaGasto(dto);

                return result.Select(x => (ObtenerListadoEspecificaGastoResponseViewModel)EspecificaGastoMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
