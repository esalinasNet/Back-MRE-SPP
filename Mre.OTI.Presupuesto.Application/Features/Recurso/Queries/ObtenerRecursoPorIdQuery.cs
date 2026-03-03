using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Recurso;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Recurso.Queries
{
    public class ObtenerRecursoPorIdQuery : IRequestHandler<ObtenerRecursoPorIdViewModel, ObtenerRecursoPorIdResponseViewModel>
    {
        private readonly IRecursoRepository _IRecursoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerRecursoPorIdQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IRecursoRepository IRecursoRepository,
            IMapper mapper)
        {
            _IRecursoRepository = IRecursoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerRecursoPorIdResponseViewModel> Handle(ObtenerRecursoPorIdViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
            VariablesGlobales.TablaRol.ANALISTA_OGTH
        });

                var result = await _IRecursoRepository.ObtenerRecursoPorId(request.idProgramacionRecurso, request.usuarioConsulta);

                if (result == null)
                {
                    return null; // O lanzar excepción si prefieres
                }

                return RecursoMap.MaptoViewModelPorId(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}