using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CajaChica;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CajaChica.Queries
{
    public class ObtenerListadoCajaChicaQuery : IRequestHandler<ObtenerListadoCajaChicaViewModel, IEnumerable<ObtenerListadoCajaChicaResponseViewModel>>
    {
        private readonly ICajaChicaRepository _ICajaChicaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoCajaChicaQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICajaChicaRepository ICajaChicaRepository,
            IMapper mapper)
        {
            _ICajaChicaRepository = ICajaChicaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoCajaChicaResponseViewModel>> Handle(ObtenerListadoCajaChicaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var dto = CajaChicaMap.MaptoCajaChicaDTO(request);
                var result = await _ICajaChicaRepository.ObtenerListadoCajaChica(dto);

                return result.Select(x => CajaChicaMap.MaptoViewModel(x));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}