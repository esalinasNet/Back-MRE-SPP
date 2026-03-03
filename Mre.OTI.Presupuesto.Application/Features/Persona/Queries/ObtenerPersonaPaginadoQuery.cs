using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Persona;
using Mre.OTI.Presupuesto.Application.Util;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Queries
{
    public class ObtenerPersonaPaginadoQuery : IRequestHandler<ObtenerPersonaPaginadoViewModel, dtPersonaPaginadoResponseViewModel>
    {
        readonly private IPersonaRepository _IPersonaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerPersonaPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPersonaRepository IPersonaRepository, IMapper mapper)
        {
            _IPersonaRepository = IPersonaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtPersonaPaginadoResponseViewModel> Handle(ObtenerPersonaPaginadoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
               // await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   
               //    VariablesGlobales.TablaRol.ANALISTA_OGTH
               //});
                var dto = PersonaMap.MaptoDTO(request);
                if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
                if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

                var result = await _IPersonaRepository.ObtenerPersonaPaginado(dto);

                var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

                var datos = _mapper.Map<IEnumerable<ObtenerPersonaPaginadoResponseViewModel>>(result);

                dtPersonaPaginadoResponseViewModel data = new dtPersonaPaginadoResponseViewModel
                {
                    draw = request.draw,
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsTotal,
                    data = datos
                };

                return data;
            }
            catch (System.Exception ex )
            {

                throw ex;
            }
            


        }
    }
}
