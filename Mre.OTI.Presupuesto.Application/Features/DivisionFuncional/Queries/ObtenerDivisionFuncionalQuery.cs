using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Queries
{
    public class ObtenerDivisionFuncionalQuery : IRequestHandler<ObtenerDivisionFuncionalViewModel, ObtenerDivisionFuncionalResponseViewModel>
    {
        private readonly IDivisionFuncionalRepository _IDivisionFuncionalRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerDivisionFuncionalQuery(IUsuarioRolRepository IUsuarioRolRepository, IDivisionFuncionalRepository IDivisionFuncionalRepository, IMapper mapper)
        {
            _IDivisionFuncionalRepository = IDivisionFuncionalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerDivisionFuncionalResponseViewModel> Handle(ObtenerDivisionFuncionalViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = DivisionFuncionalMap.MaptoDTO(request);

            var _result = await _IDivisionFuncionalRepository.ObtenerDivisionFuncional(dto);

            if (request.idDivisionFuncional == 0) throw new MreException("ingrese idDivisionFuncional");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerDivisionFuncionalResponseViewModel>(_result);
        }
    }
}
