using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Queries
{    
    public class ObtenerListadoAprobacionesCostosQuery : IRequestHandler<ObtenerListadoAprobacionesCostosViewModel, IEnumerable<ObtenerListadoAprobacionesCostosResponseViewModel>>
    {
        readonly private IAprobacionesCostosRepository _IAprobacionesCostosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoAprobacionesCostosQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAprobacionesCostosRepository IAprobacionesCostosRepository, IMapper mapper)
        {
            _IAprobacionesCostosRepository = IAprobacionesCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoAprobacionesCostosResponseViewModel>> Handle(ObtenerListadoAprobacionesCostosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
               VariablesGlobales.TablaRol.ANALISTA_OGTH
           });

                var dto = AprobacionesCostosMap.MaptoAprobacionesCostosDTO(request);

                var result = await _IAprobacionesCostosRepository.ObtenerListadoAprobacionesCostos(dto);

                return result.Select(x => (ObtenerListadoAprobacionesCostosResponseViewModel)AprobacionesCostosMap.MaptoViewModelAprobacionesCostos(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
