using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Persona.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Persona;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Queries
{
    public class ObtenerFuncionPaginadoQuery : IRequestHandler<ObtenerFuncionPaginadoViewModel, dtFuncionPaginadoResponseViewModel>
    {
        readonly private IFuncionRepository _IFuncionRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerFuncionPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IFuncionRepository IFuncionRepository, IMapper mapper)
        {
            _IFuncionRepository = IFuncionRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtFuncionPaginadoResponseViewModel> Handle(ObtenerFuncionPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = FuncionMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IFuncionRepository.ObtenerFuncionPaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerFuncionPaginadoResponseViewModel>>(result);

            dtFuncionPaginadoResponseViewModel data = new dtFuncionPaginadoResponseViewModel
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
