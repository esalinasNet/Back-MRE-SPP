using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Paises.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Paises;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Paises.Queries
{
    internal class ObtenerPaisesQuery : IRequestHandler<ObtenerPaisesViewModel, ObtenerPaisesResponseViewModel>
    {
        readonly private IPaisesRepository _IPaisesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerPaisesQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPaisesRepository IPaisesRepository, IMapper mapper)
        {
            _IPaisesRepository = IPaisesRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _mapper = mapper;
        }
        public async Task<ObtenerPaisesResponseViewModel> Handle(ObtenerPaisesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idPaises == 0) throw new MreException("ingrese idPaises");

            var result = await _IPaisesRepository.ObtenerPaises(request.idPaises);

            return _mapper.Map<ObtenerPaisesResponseViewModel>(result);
        }
    }
}
