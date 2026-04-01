using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.Json;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries
{
    public class ObtenerAeiIdCentroCostosQuery : IRequestHandler<ObtenerAeiIdCentroCostosViewModel, IEnumerable<ObtenerAeiIdCentroCostosResponseViewModel>>
    {
        readonly private IAeiCentroCostosRepository _IAeiCentroCostosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAeiIdCentroCostosQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAeiCentroCostosRepository IAeiCentroCostosRepository, IMapper mapper)
        {
            _IAeiCentroCostosRepository = IAeiCentroCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerAeiIdCentroCostosResponseViewModel>> Handle(ObtenerAeiIdCentroCostosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                       VariablesGlobales.TablaRol.ANALISTA_OGTH
                   });

                var dto = AeiCentroCostosMap.MaptoCCDTOIdCostos(request);

                var result = await _IAeiCentroCostosRepository.ObtenerAeiIdCentroCostos(dto);

                var json = JsonSerializer.Serialize(result);

                if (request.idCentroCostos == 0) throw new MreException("ingrese idAcciones");

                return result.Select(x => (ObtenerAeiIdCentroCostosResponseViewModel)AeiCentroCostosMap.MaptoViewModelAeiIdCostos(x));

                //return _mapper.Map<ObtenerAeiCentroCostosResponseViewModel>(_result);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
