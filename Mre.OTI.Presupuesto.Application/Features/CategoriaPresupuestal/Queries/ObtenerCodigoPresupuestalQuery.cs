using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CategoriaPresupuestal;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries
{
    public class ObtenerCodigoPresupuestalQuery : IRequestHandler<ObtenerCodigoPresupuestalViewModel, ObtenerCategoriaPresupuestalResponseViewModel>
    {
        readonly private ICategoriaPresupuestalRepository _ICategoriaPresupuestalRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoPresupuestalQuery(IUsuarioRolRepository IIUsuarioRolRepository, ICategoriaPresupuestalRepository ICategoriaPresupuestalRepository, IMapper mapper)
        {
            _ICategoriaPresupuestalRepository = ICategoriaPresupuestalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerCategoriaPresupuestalResponseViewModel> Handle(ObtenerCodigoPresupuestalViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = CategoriaPresupuestalMap.MaptoDTOCodigoPresupuestal(request);

            var _result = await _ICategoriaPresupuestalRepository.ObtenerCodigoPresupuestal(dto);

            if (request.codigoPresupuestal == "") throw new MreException("ingrese codigoPresupuestal");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCategoriaPresupuestalResponseViewModel>(_result);
        }
    }
}
