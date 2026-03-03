using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Encargos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Encargos.Queries
{
    public class ObtenerListadoEncargosQuery : IRequestHandler<ObtenerListadoEncargosViewModel, IEnumerable<ObtenerListadoEncargosResponseViewModel>>
    {
        private readonly IEncargosRepository _IEncargosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoEncargosQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEncargosRepository IEncargosRepository,
            IMapper mapper)
        {
            _IEncargosRepository = IEncargosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoEncargosResponseViewModel>> Handle(ObtenerListadoEncargosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var dto = EncargosMap.MaptoEncargosDTO(request);
                var result = await _IEncargosRepository.ObtenerListadoEncargos(dto);

                return result.Select(x => EncargosMap.MaptoViewModel(x));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}