using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.ProductoProyecto.Queries
{
    public class ObtenerCodigoProductoQuery : IRequestHandler<ObtenerCodigoProductoViewModel, ObtenerCodigoProductoResponseViewModel>
    {
        private readonly IProductoRepository _IProductoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoProductoQuery(IUsuarioRolRepository IUsuarioRolRepository, IProductoRepository IProductoRepository, IMapper mapper)
        {
            _IProductoRepository = IProductoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoProductoResponseViewModel> Handle(ObtenerCodigoProductoViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProductoMap.MaptoDTOCodigoProducto(request);

            var _result = await _IProductoRepository.ObtenerCodigoProducto(dto);

            if (request.producto == "") throw new MreException("ingrese producto");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoProductoResponseViewModel>(_result);
        }
    }
}
