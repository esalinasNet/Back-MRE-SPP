using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries
{
    public class ObtenerListadoCentroCostosQuery : IRequestHandler<ObtenerListadoCentroCostosViewModel, IEnumerable<ObtenerListadoCentroCostosResponseViewModel>>
    {
        private readonly ICentroCostosRepository _ICentroCostosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoCentroCostosQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICentroCostosRepository ICentroCostosRepository,
            IMapper mapper)
        {
            _ICentroCostosRepository = ICentroCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoCentroCostosResponseViewModel>> Handle(ObtenerListadoCentroCostosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = CentroCostosMap.MaptoCentroCostosDTO(request);

                var result = await _ICentroCostosRepository.ObtenerListadoCentroCostos(dto);

                return result.Select(x => (ObtenerListadoCentroCostosResponseViewModel)CentroCostosMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
