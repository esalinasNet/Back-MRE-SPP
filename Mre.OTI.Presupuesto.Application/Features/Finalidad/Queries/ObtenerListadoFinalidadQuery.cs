using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Finalidad.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Finalidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Util;

namespace Mre.OTI.Presupuesto.Application.Features.Finalidad.Queries
{
    public class ObtenerListadoFinalidadQuery : IRequestHandler<ObtenerListadoFinalidadViewModel, IEnumerable<ObtenerListadoFinalidadResponseViewModel>>
    {
        private readonly IFinalidadRepository _IFinalidadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoFinalidadQuery(IUsuarioRolRepository IUsuarioRolRepository, IFinalidadRepository IFinalidadRepository, IMapper mapper)
        {
            _IFinalidadRepository = IFinalidadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoFinalidadResponseViewModel>> Handle(ObtenerListadoFinalidadViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = FinalidadMap.MaptoFinalidadDTO(request);

                var result = await _IFinalidadRepository.ObtenerListadoFinalidad(dto);

                return result.Select(x => (ObtenerListadoFinalidadResponseViewModel)FinalidadMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}