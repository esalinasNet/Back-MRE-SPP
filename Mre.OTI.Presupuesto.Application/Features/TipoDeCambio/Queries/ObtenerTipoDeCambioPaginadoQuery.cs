using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries
{
    public class ObtenerTipoDeCambioPaginadoQuery : IRequestHandler<ObtenerTipoDeCambioPaginadoViewModel, dtTipoDeCambioPaginadoResponseViewModel>
    {
        readonly private ITipoDeCambioRepository _ITipoDeCambioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerTipoDeCambioPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, ITipoDeCambioRepository ITipoDeCambioRepository, IMapper mapper)
        {
            _ITipoDeCambioRepository = ITipoDeCambioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtTipoDeCambioPaginadoResponseViewModel> Handle(ObtenerTipoDeCambioPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = TipoDeCambioMap.MaptoDTO(request);            
            var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambioPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;                       

            var datos = _mapper.Map<IEnumerable<ObtenerTipoDeCambioPaginadoResponseViewModel>>(result);

            dtTipoDeCambioPaginadoResponseViewModel data = new dtTipoDeCambioPaginadoResponseViewModel
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
