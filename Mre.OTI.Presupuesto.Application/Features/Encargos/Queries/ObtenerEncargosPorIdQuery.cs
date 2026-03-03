using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Encargos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Encargos.Queries
{
    public class ObtenerEncargosPorIdQuery : IRequestHandler<ObtenerEncargosPorIdViewModel, ObtenerEncargosPorIdResponseViewModel>
    {
        private readonly IEncargosRepository _IEncargosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerEncargosPorIdQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEncargosRepository IEncargosRepository,
            IMapper mapper)
        {
            _IEncargosRepository = IEncargosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerEncargosPorIdResponseViewModel> Handle(ObtenerEncargosPorIdViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var result = await _IEncargosRepository.ObtenerEncargosPorId(request.idProgramacionEncargos, request.usuarioConsulta);

                if (result == null)
                {
                    return null;
                }

                return EncargosMap.MaptoViewModelPorId(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}