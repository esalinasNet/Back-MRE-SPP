using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Queries
{
    public class ObtenerCodigoDivisionQuery : IRequestHandler<ObtenerCodigoDivisionViewModel, ObtenerCodigoDivisionResponseViewModel>
    {
        private readonly IDivisionFuncionalRepository _IDivisionFuncionalRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoDivisionQuery(IUsuarioRolRepository IUsuarioRolRepository, IDivisionFuncionalRepository IDivisionFuncionalRepository, IMapper mapper)
        {
            _IDivisionFuncionalRepository = IDivisionFuncionalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public  async Task<ObtenerCodigoDivisionResponseViewModel> Handle(ObtenerCodigoDivisionViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = DivisionFuncionalMap.MaptoDTOCodigoDivision(request);

            var _result = await _IDivisionFuncionalRepository.ObtenerCodigoDivision(dto);

            if (request.divisionFuncional == "") throw new MreException("ingrese divisionFuncional");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoDivisionResponseViewModel>(_result);
        }
    }
}
