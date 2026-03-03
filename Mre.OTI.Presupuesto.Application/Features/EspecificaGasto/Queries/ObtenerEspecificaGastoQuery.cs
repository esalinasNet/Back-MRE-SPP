using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries
{
    public class ObtenerEspecificaGastoQuery : IRequestHandler<ObtenerEspecificaGastoViewModel, ObtenerEspecificaGastoResponseViewModel>
    {
        private readonly IEspecificaGastoRepository _IEspecificaGastoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerEspecificaGastoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEspecificaGastoRepository IEspecificaGastoRepository,
            IMapper mapper)
        {
            _IEspecificaGastoRepository = IEspecificaGastoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<ObtenerEspecificaGastoResponseViewModel> Handle(ObtenerEspecificaGastoViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idClasificador == 0) throw new MreException("ingrese idClasificador");

            var result = await _IEspecificaGastoRepository.ObtenerEspecificaGasto(request.idClasificador);

            return _mapper.Map<ObtenerEspecificaGastoResponseViewModel>(result);
        }
    }
}
