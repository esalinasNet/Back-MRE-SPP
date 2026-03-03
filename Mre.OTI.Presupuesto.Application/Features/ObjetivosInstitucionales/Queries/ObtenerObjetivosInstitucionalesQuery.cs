using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.ObjetivosInstitucionales;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Queries
{
    public class ObtenerObjetivosInstitucionalesQuery : IRequestHandler<ObtenerObjetivosInstitucionalesViewModel, ObtenerObjetivosInstitucionalesResponseViewModel>
    {
        readonly private IOjetivosInstitucionalesRepository _IOjetivosInstitucionalesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerObjetivosInstitucionalesQuery(IUsuarioRolRepository IIUsuarioRolRepository, IOjetivosInstitucionalesRepository IOjetivosInstitucionalesRepository, IMapper mapper)
        {
            _IOjetivosInstitucionalesRepository = IOjetivosInstitucionalesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerObjetivosInstitucionalesResponseViewModel> Handle(ObtenerObjetivosInstitucionalesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ObjetivosInstitucionalesMap.MaptoDTO(request);
            var _result = await _IOjetivosInstitucionalesRepository.ObtenerObjetivosInstitucionales(dto);

            if (request.idObjetivos == 0) throw new MreException("ingrese idObjetivo");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerObjetivosInstitucionalesResponseViewModel>(_result);
        }
    }
}
