using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.OtrosGastos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Queries
{
    public class ObtenerOtrosGastosPorIdQuery : IRequestHandler<ObtenerOtrosGastosPorIdViewModel, ObtenerOtrosGastosPorIdResponseViewModel>
    {
        private readonly IOtrosGastosRepository _IOtrosGastosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerOtrosGastosPorIdQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IOtrosGastosRepository IOtrosGastosRepository,
            IMapper mapper)
        {
            _IOtrosGastosRepository = IOtrosGastosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerOtrosGastosPorIdResponseViewModel> Handle(ObtenerOtrosGastosPorIdViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var result = await _IOtrosGastosRepository.ObtenerOtrosGastosPorId(request.idProgramacionOtrosGastos, request.usuarioConsulta);

                // ✅ CORRECCIÓN: Manejar cuando result es NULL
                if (result == null)
                {
                    return null; // O puedes devolver un objeto vacío si prefieres
                }

                return OtrosGastosMap.MaptoViewModelPorId(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}