using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Util;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries
{
    public class ObtenerAeiCentroCostosQuery : IRequestHandler<ObtenerAeiCentroCostosViewModel, IEnumerable<ObtenerAeiCentroCostosResponseViewModel>>
    {
        readonly private IAeiCentroCostosRepository _IAeiCentroCostosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAeiCentroCostosQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAeiCentroCostosRepository IAeiCentroCostosRepository, IMapper mapper)
        {
            _IAeiCentroCostosRepository = IAeiCentroCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerAeiCentroCostosResponseViewModel>> Handle(ObtenerAeiCentroCostosViewModel request, CancellationToken cancellationToken)
        {
            try
            {                            
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                       VariablesGlobales.TablaRol.ANALISTA_OGTH
                   });

                var dto = AeiCentroCostosMap.MaptoCCDTO(request);

                var result = await _IAeiCentroCostosRepository.ObtenerAeiCentroCostos(dto);

                var json = JsonSerializer.Serialize(result);

                if (request.idAcciones == 0) throw new MreException("ingrese idAcciones");

                return result.Select(x => (ObtenerAeiCentroCostosResponseViewModel)AeiCentroCostosMap.MaptoViewModelAeiCostos(x));

                    //return _mapper.Map<ObtenerAeiCentroCostosResponseViewModel>(_result);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
