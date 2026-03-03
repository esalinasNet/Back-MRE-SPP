using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Proyecto;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Proyecto.Queries
{
    public class ObtenerProyectoPorIdQuery : IRequestHandler<ObtenerProyectoPorIdViewModel, ObtenerProyectoPorIdResponseViewModel>
    {
        private readonly IProyectoRepository _IProyectoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerProyectoPorIdQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IProyectoRepository IProyectoRepository,
            IMapper mapper)
        {
            _IProyectoRepository = IProyectoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerProyectoPorIdResponseViewModel> Handle(ObtenerProyectoPorIdViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var result = await _IProyectoRepository.ObtenerProyectoPorId(request.idProgramacionProyecto, request.usuarioConsulta);
                return ProyectoMap.MaptoViewModelPorId(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}