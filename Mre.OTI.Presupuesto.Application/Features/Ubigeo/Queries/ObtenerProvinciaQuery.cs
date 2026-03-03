using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerProvinciaQuery : IRequestHandler<ObtenerProvinciaViewModel, ObtenerProvinciaResponseViewModel>
    {
        private readonly IUbigeoRepository _IUbigeoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerProvinciaQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IUbigeoRepository IUbigeoRepository,
            IMapper mapper)
        {
            _IUbigeoRepository = IUbigeoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerProvinciaResponseViewModel> Handle(ObtenerProvinciaViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.ubigeo == "") throw new MreException("ingrese Ubigeo");

            var result = await _IUbigeoRepository.ObtenerUbigeoProvincia(request.ubigeo);

            return _mapper.Map<ObtenerProvinciaResponseViewModel>(result);
        }
    }
}
