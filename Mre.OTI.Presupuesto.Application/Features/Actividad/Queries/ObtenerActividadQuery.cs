using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Actividad.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Actividad;
using Mre.OTI.Presupuesto.Application.Responses.Actividad;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Actividad.Queries
{
    public class ObtenerActividadQuery : IRequestHandler<ObtenerActividadViewModel, ObtenerActividadResponseViewModel>
    {
        readonly private IActividadRepository _IActividadRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerActividadQuery(IUsuarioRolRepository IIUsuarioRolRepository, IActividadRepository IActividadRepository, IMapper mapper)
        {
            _IActividadRepository = IActividadRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _mapper = mapper;
        }

        public async Task<ObtenerActividadResponseViewModel> Handle(ObtenerActividadViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idActividad == 0) throw new MreException("ingrese idActividad");

            var result = await _IActividadRepository.ObtenerActividad(request.idActividad);

            return _mapper.Map<ObtenerActividadResponseViewModel>(result);
        }
    }
}
