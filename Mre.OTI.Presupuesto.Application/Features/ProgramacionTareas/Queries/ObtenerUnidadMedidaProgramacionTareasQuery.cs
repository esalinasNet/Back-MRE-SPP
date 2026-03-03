using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries
{
    public class ObtenerUnidadMedidaProgramacionTareasQuery : IRequestHandler<ObtenerUnidadMedidaProgramacionTareasViewModel, ObtenerUidadMedidaProgramacionTareasResponseViewModel>
    {
        private readonly IProgramacionTareasRepository _IProgramacionTareasRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerUnidadMedidaProgramacionTareasQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionTareasRepository IProgramacionTareasRepository, IMapper mapper)
        {
            _IProgramacionTareasRepository = IProgramacionTareasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerUidadMedidaProgramacionTareasResponseViewModel> Handle(ObtenerUnidadMedidaProgramacionTareasViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProgramacionTareasMap.MaptoDTOUnidadMedidaProgramacionTareas(request);

            var _result = await _IProgramacionTareasRepository.ObtenerUnidadMedidaProgramacionTareas(dto);

            if (request.idUnidadMedida == 0) throw new MreException("ingrese Id UidadMedida");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerUidadMedidaProgramacionTareasResponseViewModel>(_result);
        }
    }
}

