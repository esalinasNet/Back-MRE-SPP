using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Finalidad.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.Finalidad.Queries
{
    public class ObtenerCodigoFinalidadQuery : IRequestHandler<ObtenerCodigoFinalidadViewModel, ObtenerCodigoFinalidadResponseViewModel>
    {
        private readonly IFinalidadRepository _IFinalidadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoFinalidadQuery(IUsuarioRolRepository IUsuarioRolRepository, IFinalidadRepository IFinalidadRepository, IMapper mapper)
        {
            _IFinalidadRepository = IFinalidadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoFinalidadResponseViewModel> Handle(ObtenerCodigoFinalidadViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = FinalidadMap.MaptoDTOCodigoFinalidad(request);

            var _result = await _IFinalidadRepository.ObtenerCodigoFinalidad(dto);

            if (request.finalidad == "") throw new MreException("ingrese finalidad");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoFinalidadResponseViewModel>(_result);
        }
    }
}
