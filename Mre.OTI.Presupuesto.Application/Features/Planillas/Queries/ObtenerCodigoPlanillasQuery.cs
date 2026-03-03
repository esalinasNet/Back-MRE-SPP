using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas.Queries
{    
    public class ObtenerCodigoPlanillasQuery : IRequestHandler<ObtenerCodigoPlanillasViewModel, ObtenerCodigoPlanillasResponseViewModel>
    {
        readonly private IPlanillasRepository _IPlanillasRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerCodigoPlanillasQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPlanillasRepository IPlanillasRepository, IMapper mapper)
        {
            _IPlanillasRepository = IPlanillasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoPlanillasResponseViewModel> Handle(ObtenerCodigoPlanillasViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                VariablesGlobales.TablaRol.ANALISTA_OGTH
            });

            var dto = PlanillasMap.MaptoDTOCodigoPlanillas(request);

            var _result = await _IPlanillasRepository.ObtenerCodigoPlanillas(dto);

            if (request.nroDocumento == "") throw new MreException("ingrese numero de docuemnto");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoPlanillasResponseViewModel>(_result);
        }
    }
}
