using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using Mre.OTI.Presupuesto.Application.Responses.Proyecto;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Proyecto.Queries
{
    public class ObtenerListadoProyectoQuery : IRequestHandler<ObtenerListadoProyectoViewModel, IEnumerable<ObtenerListadoProyectoResponseViewModel>>
    {
        private readonly IProyectoRepository _IProyectoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoProyectoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IProyectoRepository IProyectoRepository,
            IMapper mapper)
        {
            _IProyectoRepository = IProyectoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoProyectoResponseViewModel>> Handle(ObtenerListadoProyectoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var dto = ProyectoMap.MaptoProyectoDTO(request);
                var result = await _IProyectoRepository.ObtenerListadoProyecto(dto);
                return result.Select(x => ProyectoMap.MaptoViewModel(x));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}