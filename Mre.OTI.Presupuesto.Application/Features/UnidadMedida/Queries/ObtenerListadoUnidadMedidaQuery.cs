using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.UnidadMedida;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Util;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries
{
    public class ObtenerListadoUnidadMedidaQuery : IRequestHandler<ObtenerListadoUnidadMedidaViewModel, IEnumerable<ObtenerListadoUnidadMedidaResponseViewModel>>
    {
        private readonly IUnidadMedidaRepository _IUnidadMedidaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoUnidadMedidaQuery(IUsuarioRolRepository IUsuarioRolRepository, IUnidadMedidaRepository IUnidadMedidaRepository, IMapper mapper)
        {
            _IUnidadMedidaRepository = IUnidadMedidaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoUnidadMedidaResponseViewModel>> Handle(ObtenerListadoUnidadMedidaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = UnidadMedidaMap.MaptoUnidadMedidaDTO(request);

                var result = await _IUnidadMedidaRepository.ObtenerListadoUnidadMedida(dto);

                return result.Select(x => (ObtenerListadoUnidadMedidaResponseViewModel)UnidadMedidaMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
