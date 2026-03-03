using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Viaticos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Viaticos.Queries
{
    public class ObtenerListadoViaticosQuery : IRequestHandler<ObtenerListadoViaticosViewModel, IEnumerable<ObtenerListadoViaticosResponseViewModel>>
    {
        private readonly IViaticosRepository _IViaticosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoViaticosQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IViaticosRepository IViaticosRepository,
            IMapper mapper)
        {
            _IViaticosRepository = IViaticosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoViaticosResponseViewModel>> Handle(ObtenerListadoViaticosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var dto = ViaticosMap.MaptoViaticosDTO(request);
                var result = await _IViaticosRepository.ObtenerListadoViaticos(dto);
                return result.Select(x => ViaticosMap.MaptoViewModel(x));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}