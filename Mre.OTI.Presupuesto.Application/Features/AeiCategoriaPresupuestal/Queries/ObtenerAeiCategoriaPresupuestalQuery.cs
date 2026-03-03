using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AeiCategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCategoriaPresupuestal.Queries
{
    public class ObtenerAeiCategoriaPresupuestalQuery : IRequestHandler<ObtenerAeiCategoriaPresupuestalViewModel, IEnumerable<ObtenerAeiCategoriaPresupuestalResponseViewModel>>
    {        
        readonly private IAeiCategoriaPresupuestalRepository _IAeiCategoriaPresupuestalRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAeiCategoriaPresupuestalQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAeiCategoriaPresupuestalRepository IAeiCategoriaPresupuestalRepository, IMapper mapper)
        {
            _IAeiCategoriaPresupuestalRepository = IAeiCategoriaPresupuestalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerAeiCategoriaPresupuestalResponseViewModel>> Handle(ObtenerAeiCategoriaPresupuestalViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                       VariablesGlobales.TablaRol.ANALISTA_OGTH
                   });

                var dto = AeiCategoriaPresupuestalMap.MaptoCCDTO(request);

                var result = await _IAeiCategoriaPresupuestalRepository.ObtenerAeiCategoriaPresupuestal(dto);

                var json = JsonSerializer.Serialize(result);

                if (request.idPresupuestal == 0) throw new MreException("ingrese idPresupuestal");

                return result.Select(x => (ObtenerAeiCategoriaPresupuestalResponseViewModel)AeiCategoriaPresupuestalMap.MaptoViewModelAeiCostos(x));

                //return _mapper.Map<ObtenerAeiCentroCostosResponseViewModel>(_result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
