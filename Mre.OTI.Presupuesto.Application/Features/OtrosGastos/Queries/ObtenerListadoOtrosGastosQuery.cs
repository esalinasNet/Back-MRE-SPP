using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.OtrosGastos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Queries
{
    public class ObtenerListadoOtrosGastosQuery : IRequestHandler<ObtenerListadoOtrosGastosViewModel, IEnumerable<ObtenerListadoOtrosGastosResponseViewModel>>
    {
        private readonly IOtrosGastosRepository _IOtrosGastosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoOtrosGastosQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IOtrosGastosRepository IOtrosGastosRepository,
            IMapper mapper)
        {
            _IOtrosGastosRepository = IOtrosGastosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoOtrosGastosResponseViewModel>> Handle(ObtenerListadoOtrosGastosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var dto = OtrosGastosMap.MaptoOtrosGastosDTO(request);
                var result = await _IOtrosGastosRepository.ObtenerListadoOtrosGastos(dto);

                return result.Select(x => OtrosGastosMap.MaptoViewModel(x));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}