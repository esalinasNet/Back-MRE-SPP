using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CajaChica;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CajaChica.Queries
{
    public class ObtenerCajaChicaPorIdQuery : IRequestHandler<ObtenerCajaChicaPorIdViewModel, ObtenerCajaChicaPorIdResponseViewModel>
    {
        private readonly ICajaChicaRepository _ICajaChicaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCajaChicaPorIdQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICajaChicaRepository ICajaChicaRepository,
            IMapper mapper)
        {
            _ICajaChicaRepository = ICajaChicaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCajaChicaPorIdResponseViewModel> Handle(ObtenerCajaChicaPorIdViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var result = await _ICajaChicaRepository.ObtenerCajaChicaPorId(request.idProgramacionCajaChica, request.usuarioConsulta);

                if (result == null)
                {
                    return null;
                }

                return CajaChicaMap.MaptoViewModelPorId(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}