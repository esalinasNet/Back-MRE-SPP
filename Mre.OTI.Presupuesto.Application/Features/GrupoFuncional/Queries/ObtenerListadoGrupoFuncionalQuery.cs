using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.GrupoFuncional;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.GrupoFuncional.Queries
{
    public class ObtenerListadoGrupoFuncionalQuery : IRequestHandler<ObtenerListadoGrupoFuncionalViewModel, IEnumerable<ObtenerListadoGrupoFuncionalResponseViewModel>>
    {
        private readonly IGrupoFuncionalRepository _IGrupoFuncionalRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoGrupoFuncionalQuery(IUsuarioRolRepository IUsuarioRolRepository, IGrupoFuncionalRepository IGrupoFuncionalRepository, IMapper mapper)
        {
            _IGrupoFuncionalRepository = IGrupoFuncionalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoGrupoFuncionalResponseViewModel>> Handle(ObtenerListadoGrupoFuncionalViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = GrupoFuncionalMap.MaptoGrupoFuncionalDTO(request);

                var result = await _IGrupoFuncionalRepository.ObtenerListadoGrupoFuncional(dto);

                return result.Select(x => (ObtenerListadoGrupoFuncionalResponseViewModel)GrupoFuncionalMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
