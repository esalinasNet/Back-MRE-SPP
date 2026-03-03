using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional;
using Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries
{
    public class ObtenerCodigoGrupoFuncionalQuery : IRequestHandler<ObtenerCodigoGrupoFuncionalViewModel, ObtenerCodigoGrupoFuncionalResponseViewModel>
    {
        private readonly IGrupoFuncionalRepository _IGrupoFuncionalRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoGrupoFuncionalQuery(IUsuarioRolRepository IUsuarioRolRepository, IGrupoFuncionalRepository IGrupoFuncionalRepository, IMapper mapper)
        {
            _IGrupoFuncionalRepository = IGrupoFuncionalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoGrupoFuncionalResponseViewModel> Handle(ObtenerCodigoGrupoFuncionalViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = GrupoFuncionalMap.MaptoDTOCodigoGrupo(request);

            var _result = await _IGrupoFuncionalRepository.ObtenerCodigoGrupo(dto);

            if (request.grupoFuncional == "") throw new MreException("ingrese grupoFuncional");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoGrupoFuncionalResponseViewModel>(_result);
        }
    }
}
