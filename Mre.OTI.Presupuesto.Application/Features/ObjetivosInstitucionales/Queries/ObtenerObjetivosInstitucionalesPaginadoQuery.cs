using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.ObjetivosInstitucionales;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Queries
{
    public class ObtenerObjetivosInstitucionalesPaginadoQuery : IRequestHandler<ObtenerObjetivosInstitucionalesPaginadoViewModel, dtObjetivosPaginadoInstitucionalesResponseViewModel>
    {
        readonly private IOjetivosInstitucionalesRepository _IOjetivosInstitucionalesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerObjetivosInstitucionalesPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IOjetivosInstitucionalesRepository IOjetivosInstitucionalesRepository, IMapper mapper)
        {
            _IOjetivosInstitucionalesRepository = IOjetivosInstitucionalesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtObjetivosPaginadoInstitucionalesResponseViewModel> Handle(ObtenerObjetivosInstitucionalesPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = ObjetivosInstitucionalesMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IOjetivosInstitucionalesRepository.ObtenerObjetivosInstitucionalesPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerObjetivosInstitucionalesPaginadoResponseViewModel>>(result);

            dtObjetivosPaginadoInstitucionalesResponseViewModel data = new dtObjetivosPaginadoInstitucionalesResponseViewModel
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
