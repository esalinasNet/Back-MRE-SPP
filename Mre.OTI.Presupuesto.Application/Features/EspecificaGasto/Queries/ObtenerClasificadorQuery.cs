using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries
{
    public class ObtenerClasificadorQuery : IRequestHandler<ObtenerClasificadorViewModel, ObtenerClasificadorResponseViewModel>
    {
        private readonly IEspecificaGastoRepository _IEspecificaGastoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerClasificadorQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEspecificaGastoRepository IEspecificaGastoRepository,
            IMapper mapper)
        {
            _IEspecificaGastoRepository = IEspecificaGastoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerClasificadorResponseViewModel> Handle(ObtenerClasificadorViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.Clasificador == "") throw new MreException("ingrese Clasificador");

            var result = await _IEspecificaGastoRepository.ObtenerClasificador(request.Clasificador);

            return _mapper.Map<ObtenerClasificadorResponseViewModel>(result);
        }
    }
}
