using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
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
    public class ObtenerGrupoFuncionalPaginadoQuery : IRequestHandler<ObtenerGrupoFuncionalPaginadoViewModel, dtGrupoFuncionalPaginadoResponseViewModel>
    {
        private readonly IGrupoFuncionalRepository _IGrupoFuncionalRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerGrupoFuncionalPaginadoQuery(IUsuarioRolRepository IUsuarioRolRepository, IGrupoFuncionalRepository IGrupoFuncionalRepository, IMapper mapper)
        {
            _IGrupoFuncionalRepository = IGrupoFuncionalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtGrupoFuncionalPaginadoResponseViewModel> Handle(ObtenerGrupoFuncionalPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = GrupoFuncionalMap.MaptoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IGrupoFuncionalRepository.ObtenerGrupoFuncionalPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerGrupoFuncionalPaginadoResponseViewModel>>(result);

            dtGrupoFuncionalPaginadoResponseViewModel data = new dtGrupoFuncionalPaginadoResponseViewModel
            {
                draw = request.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = datos
            };

            return data;
        }
    }
}
