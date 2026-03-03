using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.CategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries
{
    public class ObtenerCategoriaPresupuestalPaginadoQuery : IRequestHandler<ObtenerCategoriaPresupuestalPaginadoViewModel, dtCategoriaPresupuestalPaginadoResponseViewModel>
    {
        readonly private ICategoriaPresupuestalRepository _ICategoriaPresupuestalRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCategoriaPresupuestalPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, ICategoriaPresupuestalRepository ICategoriaPresupuestalRepository, IMapper mapper)
        {
            _ICategoriaPresupuestalRepository = ICategoriaPresupuestalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtCategoriaPresupuestalPaginadoResponseViewModel> Handle(ObtenerCategoriaPresupuestalPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = CategoriaPresupuestalMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _ICategoriaPresupuestalRepository.ObtenerCategoriaPresupuestalPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerCategoriaPresupuestalPaginadoResponseViewModel>>(result);

            dtCategoriaPresupuestalPaginadoResponseViewModel data = new dtCategoriaPresupuestalPaginadoResponseViewModel
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
