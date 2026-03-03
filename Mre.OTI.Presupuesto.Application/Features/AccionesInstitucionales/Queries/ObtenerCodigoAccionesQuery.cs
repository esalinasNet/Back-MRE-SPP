using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AccionesInstitucionales;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Queries
{
    public class ObtenerCodigoAccionesQuery : IRequestHandler<ObtenerCodigoAccionesViewModel, ObtenerCodigoAccionesResponseViewModel>
    {
        readonly private IAccionesInstitucionalesRepository _IAccionesInstitucionalesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoAccionesQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesInstitucionalesRepository IAccionesInstitucionalesRepository, IMapper mapper)
        {
            _IAccionesInstitucionalesRepository = IAccionesInstitucionalesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoAccionesResponseViewModel> Handle(ObtenerCodigoAccionesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = AccionesInstitucionalesMap.MaptoDTOCodigoAcciones(request);

            var _result = await _IAccionesInstitucionalesRepository.ObtenerCodigoAcciones(dto);

            if (request.codigoAcciones == "") throw new MreException("ingrese codigoAcciones");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoAccionesResponseViewModel>(_result);
        }
    }
}
