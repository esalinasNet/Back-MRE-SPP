using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Politicas.Queries
{
    public class ObtenerCodigoPoliticasQuery : IRequestHandler<ObtenerCodigoPoliticasViewModel, ObtenerCodigoPoliticasResponseViewModel>
    {
        readonly private IPoliticasRepository _IPoliticasRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerCodigoPoliticasQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPoliticasRepository IPoliticasRepository, IMapper mapper)
        {
            _IPoliticasRepository = IPoliticasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoPoliticasResponseViewModel> Handle(ObtenerCodigoPoliticasViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = PoliticasMap.MaptoDTOCodigoPoliticas(request);
            var _result = await _IPoliticasRepository.ObtenerCodigoPoliticas(dto);

            if (request.codigoPoliticas == "") throw new MreException("ingrese codigoPoliticas");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoPoliticasResponseViewModel>(_result);
        }
    }
}
