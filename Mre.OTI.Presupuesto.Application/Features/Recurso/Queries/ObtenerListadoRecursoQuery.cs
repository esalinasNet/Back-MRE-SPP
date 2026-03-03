using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Recurso.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Recurso;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Recurso.Queries
{
    public class ObtenerListadoRecursoQuery : IRequestHandler<ObtenerListadoRecursoViewModel, IEnumerable<ObtenerListadoRecursoResponseViewModel>>
    {
        private readonly IRecursoRepository _IRecursoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoRecursoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IRecursoRepository IRecursoRepository,
            IMapper mapper)
        {
            _IRecursoRepository = IRecursoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoRecursoResponseViewModel>> Handle(ObtenerListadoRecursoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
           VariablesGlobales.TablaRol.ANALISTA_OGTH
        });

                var dto = RecursoMap.MaptoRecursoDTO(request);
                var result = await _IRecursoRepository.ObtenerListadoRecurso(dto);

                if (result == null || !result.Any())
                {
                    return Enumerable.Empty<ObtenerListadoRecursoResponseViewModel>(); // ✅ RETORNA LISTA VACÍA
                }

                return result.Select(x => RecursoMap.MaptoViewModel(x));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}