using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Util;

namespace Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Queries
{
    public class ObtenerListadoProductoQuery : IRequestHandler<ObtenerListadoProductoViewModel, IEnumerable<ObtenerListadoProductoResponseViewModel>>
    {
        private readonly IProductoRepository _IProductoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoProductoQuery(IUsuarioRolRepository IUsuarioRolRepository, IProductoRepository IProductoRepository, IMapper mapper)
        {
            _IProductoRepository = IProductoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoProductoResponseViewModel>> Handle(ObtenerListadoProductoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ProductoMap.MaptoProductoDTO(request);

                var result = await _IProductoRepository.ObtenerListadoProducto(dto);

                return result.Select(x => (ObtenerListadoProductoResponseViewModel)ProductoMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}