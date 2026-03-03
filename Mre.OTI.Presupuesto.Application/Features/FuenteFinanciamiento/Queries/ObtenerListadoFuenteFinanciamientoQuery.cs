using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.FuenteFinanciamiento;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.FuenteFinanciamiento.Queries
{
    public class ObtenerListadoFuenteFinanciamientoQuery : IRequestHandler<ObtenerListadoFuenteFinanciamientoViewModel, IEnumerable<ObtenerListadoFuenteFinanciamientoResponseViewModel>>
    {
        readonly private IFuenteFinanciamientoRepository _IFuenteFinanciamientoRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoFuenteFinanciamientoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IFuenteFinanciamientoRepository IFuenteFinanciamientoRepository, IMapper mapper)
        {
            _IFuenteFinanciamientoRepository = IFuenteFinanciamientoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoFuenteFinanciamientoResponseViewModel>> Handle(ObtenerListadoFuenteFinanciamientoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = FuenteFinanciamientoMap.MaptoFuenteDTO(request);

                var result = await _IFuenteFinanciamientoRepository.ObtenerListadoFuente(dto);

                return result.Select(x => (ObtenerListadoFuenteFinanciamientoResponseViewModel)FuenteFinanciamientoMap.MaptoViewModelFuente(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
