using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Actividad.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Actividad;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Actividad.Queries
{
    public class ObtenerListadoActividadQuery : IRequestHandler<ObtenerListadoActividadViewModel, IEnumerable<ObtenerListadoActividadResponseViewModel>>
    {
        private readonly IActividadRepository _IActividadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoActividadQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IActividadRepository IActividadRepository,
            IMapper mapper)
        {
            _IActividadRepository = IActividadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoActividadResponseViewModel>> Handle(ObtenerListadoActividadViewModel request, CancellationToken cancellationToken)
        {

            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ActividadMap.MaptoActividadDTO(request);

                var result = await _IActividadRepository.ObtenerListadoActividad(dto);

                return result.Select(x => (ObtenerListadoActividadResponseViewModel)ActividadMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
