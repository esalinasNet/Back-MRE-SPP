using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Cmn;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Cmn.Queries
{
    public class ObtenerListadoCmnQuery : IRequestHandler<ObtenerListadoCmnViewModel, IEnumerable<ObtenerListadoCmnResponseViewModel>>
    {
        private readonly ICmnRepository _ICmnRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoCmnQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICmnRepository ICmnRepository,
            IMapper mapper)
        {
            _ICmnRepository = ICmnRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoCmnResponseViewModel>> Handle(ObtenerListadoCmnViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var dto = CmnMap.MaptoCmnDTO(request);
                var result = await _ICmnRepository.ObtenerListadoCmn(dto);
                return result.Select(x => CmnMap.MaptoViewModel(x));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}