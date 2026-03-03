using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerUnidadMedidaProgramacionAccionesQuery : IRequestHandler<ObtenerUnidadMedidaProgramacionAccionesViewModel, ObtenerUidadMedidaProgramacionAccionesResponseViewModel>
    {
        private readonly IProgramacionAccionesRepository _IProgramacionAccionesRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerUnidadMedidaProgramacionAccionesQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionAccionesRepository IProgramacionAccionesRepository, IMapper mapper)
        {
            _IProgramacionAccionesRepository = IProgramacionAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerUidadMedidaProgramacionAccionesResponseViewModel> Handle(ObtenerUnidadMedidaProgramacionAccionesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProgramacionAccionesMap.MaptoDTOUnidadMedidaProgramacionAcciones(request);

            var _result = await _IProgramacionAccionesRepository.ObtenerUnidadMedidaProgramacionAcciones(dto);

            if (request.idUnidadMedida == 0) throw new MreException("ingrese Id UidadMedida");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerUidadMedidaProgramacionAccionesResponseViewModel>(_result);
        }
    }
}

