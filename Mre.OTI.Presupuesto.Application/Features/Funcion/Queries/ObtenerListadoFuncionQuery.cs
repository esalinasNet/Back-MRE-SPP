using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Queries
{
    public class ObtenerListadoFuncionQuery : IRequestHandler<ObtenerListadoFuncionViewModel, IEnumerable<ObtenerListadoFuncionResponseViewModel>>
    {
        private readonly IFuncionRepository _IFuncionRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoFuncionQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IFuncionRepository IFuncionRepository,
            IMapper mapper)
        {
            _IFuncionRepository = IFuncionRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoFuncionResponseViewModel>> Handle(ObtenerListadoFuncionViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = FuncionMap.MaptoFuncionDTO(request);

                var result = await _IFuncionRepository.ObtenerListadoFuncion(dto);

                return result.Select(x => (ObtenerListadoFuncionResponseViewModel)FuncionMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

