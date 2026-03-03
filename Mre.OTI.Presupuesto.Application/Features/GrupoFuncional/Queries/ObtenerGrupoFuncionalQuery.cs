using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional;
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
    public class ObtenerGrupoFuncionalQuery : IRequestHandler<ObtenerGrupoFuncionalViewModel, ObtenerGrupoFuncionalResponseViewModel>
    {
        private readonly IGrupoFuncionalRepository _IGrupoFuncionalRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerGrupoFuncionalQuery(IUsuarioRolRepository IUsuarioRolRepository, IGrupoFuncionalRepository IGrupoFuncionalRepository, IMapper mapper)
        {
            _IGrupoFuncionalRepository = IGrupoFuncionalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerGrupoFuncionalResponseViewModel> Handle(ObtenerGrupoFuncionalViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = GrupoFuncionalMap.MaptoDTO(request);

            var _result = await _IGrupoFuncionalRepository.ObtenerGrupoFuncional(dto);

            if (request.idGrupoFuncional == 0) throw new MreException("ingrese idGrupoFuncional");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerGrupoFuncionalResponseViewModel>(_result);
        }
    }
}
