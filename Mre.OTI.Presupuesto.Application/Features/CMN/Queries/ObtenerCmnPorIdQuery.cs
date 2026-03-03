using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Cmn;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Cmn.Queries
{
    public class ObtenerCmnPorIdQuery : IRequestHandler<ObtenerCmnPorIdViewModel, ObtenerCmnPorIdResponseViewModel>
    {
        private readonly ICmnRepository _ICmnRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCmnPorIdQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICmnRepository ICmnRepository,
            IMapper mapper)
        {
            _ICmnRepository = ICmnRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCmnPorIdResponseViewModel> Handle(ObtenerCmnPorIdViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var result = await _ICmnRepository.ObtenerCmnPorId(request.idProgramacionCmn, request.usuarioConsulta);
                return CmnMap.MaptoViewModelPorId(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}