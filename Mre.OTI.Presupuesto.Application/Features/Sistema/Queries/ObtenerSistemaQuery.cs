using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Sistema.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Sistema.Queries
{
    public class ObtenerSistemaQuery : IRequestHandler<ObtenerSistemaViewModel, ObtenerSistemaResponseViewModel>
    {
        readonly private ISistemaRepository _ISistemaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerSistemaQuery(IUsuarioRolRepository IIUsuarioRolRepository, ISistemaRepository ISistemaRepository, IMapper mapper)
        {
            _ISistemaRepository = ISistemaRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _mapper = mapper;
        }

        public async Task<ObtenerSistemaResponseViewModel> Handle(ObtenerSistemaViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idSistema == 0) throw new MreException("ingrese idSistema");

            var result = await _ISistemaRepository.ObtenerSistema(request.idSistema);

            return _mapper.Map<ObtenerSistemaResponseViewModel>(result);
        }
    }
}
