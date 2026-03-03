using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Anios.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Anios;
using Mre.OTI.Presupuesto.Application.Responses.Anios;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Anios.Queries
{
    public class ObtenerAniosQuery : IRequestHandler<ObtenerAniosViewModel, ObtenerAniosResponseViewModel>
    {
        readonly private IAniosRepository _IAniosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerAniosQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAniosRepository IAniosRepository, IMapper mapper)
        {
            _IAniosRepository = IAniosRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _mapper = mapper;
        }

        public async Task<ObtenerAniosResponseViewModel> Handle(ObtenerAniosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idAnio == 0) throw new MreException("ingrese idAnios");

            var result = await _IAniosRepository.ObtenerAnios(request.idAnio);

            return _mapper.Map<ObtenerAniosResponseViewModel>(result);
        }
    }
}
