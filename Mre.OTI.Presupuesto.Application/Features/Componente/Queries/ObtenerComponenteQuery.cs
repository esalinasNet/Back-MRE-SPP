using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Componente.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Componente.Queries
{
    public class ObtenerComponenteQuery : IRequestHandler<ObtenerComponenteViewModel, ObtenerComponenteResponseViewModel>
    {
        readonly private IComponenteRepository _IComponenteRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerComponenteQuery(IUsuarioRolRepository IIUsuarioRolRepository, IComponenteRepository IComponenteRepository, IMapper mapper)
        {
            _IComponenteRepository = IComponenteRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _mapper = mapper;
        }

        public async Task<ObtenerComponenteResponseViewModel> Handle(ObtenerComponenteViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idComponente == 0) throw new MreException("ingrese idComponente");

            var result = await _IComponenteRepository.ObtenerComponente(request.idComponente);

            return _mapper.Map<ObtenerComponenteResponseViewModel>(result);
        }
    }
}
