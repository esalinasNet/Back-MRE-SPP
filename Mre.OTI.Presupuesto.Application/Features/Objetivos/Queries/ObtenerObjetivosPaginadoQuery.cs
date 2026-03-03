using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries
{
    public class ObtenerObjetivosPaginadoQuery : IRequestHandler<ObtenerObjetivosPaginadoViewModel, dtObjetivosPaginadoResponseViewModel>
    {
        readonly private IOjetivosRepository _IOjetivosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerObjetivosPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IOjetivosRepository IOjetivosRepository, IMapper mapper)
        {
            _IOjetivosRepository = IOjetivosRepository; 
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtObjetivosPaginadoResponseViewModel> Handle(ObtenerObjetivosPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = ObjetivosMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IOjetivosRepository.ObtenerObjetivosPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerObjetivosPaginadoResponseViewModel>>(result);

            dtObjetivosPaginadoResponseViewModel data = new dtObjetivosPaginadoResponseViewModel
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
