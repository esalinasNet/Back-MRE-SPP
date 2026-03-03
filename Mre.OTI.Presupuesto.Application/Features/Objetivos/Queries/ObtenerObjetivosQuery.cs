using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries
{
    public class ObtenerObjetivosQuery : IRequestHandler<ObtenerObjetivosViewModel, ObtenerObjetivosResponseViewModel>
    {
        readonly private IOjetivosRepository _IOjetivosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerObjetivosQuery(IUsuarioRolRepository IIUsuarioRolRepository, IOjetivosRepository IOjetivosRepository, IMapper mapper)
        {
            _IOjetivosRepository = IOjetivosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerObjetivosResponseViewModel> Handle(ObtenerObjetivosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ObjetivosMap.MaptoDTO(request);
            var _result = await _IOjetivosRepository.ObtenerObjetivos (dto);

            if (request.idObjetivos == 0) throw new MreException("ingrese idObjetivo");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerObjetivosResponseViewModel>(_result);
        }
    }
}
