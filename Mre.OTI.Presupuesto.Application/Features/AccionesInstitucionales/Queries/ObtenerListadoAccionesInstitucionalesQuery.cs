using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AccionesInstitucionales;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.AccionesInstitucionales.Queries
{
    public class ObtenerListadoAccionesInstitucionalesQuery : IRequestHandler<ObtenerListadoAccionesInstitucionalesViewModel, IEnumerable<ObtenerListadoAccionesInstitucionalesResponseViewModel>>
    {
        readonly private IAccionesInstitucionalesRepository _IAccionesInstitucionalesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoAccionesInstitucionalesQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesInstitucionalesRepository IAccionesInstitucionalesRepository, IMapper mapper)
        {
            _IAccionesInstitucionalesRepository = IAccionesInstitucionalesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoAccionesInstitucionalesResponseViewModel>> Handle(ObtenerListadoAccionesInstitucionalesViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = AccionesInstitucionalesMap.MaptoAccionesInstitucionalesDTO(request);

                var result = await _IAccionesInstitucionalesRepository.ObtenerListadoAcciones(dto);

                return result.Select(x => (ObtenerListadoAccionesInstitucionalesResponseViewModel)AccionesInstitucionalesMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
