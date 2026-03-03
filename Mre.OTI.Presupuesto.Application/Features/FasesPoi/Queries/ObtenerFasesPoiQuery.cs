using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.FasesPoi;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.FasesPoi.Queries
{
    public class ObtenerFasesPoiQuery : IRequestHandler<ObtenerFasesPoiViewModel, ObtenerFasesPoiResponseViewModel>
    {
        readonly private IFasesPoiRepository _IFasesPoiRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerFasesPoiQuery(IUsuarioRolRepository IIUsuarioRolRepository, IFasesPoiRepository IFasesPoiRepository, IMapper mapper)
        {
            _IFasesPoiRepository = IFasesPoiRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerFasesPoiResponseViewModel> Handle(ObtenerFasesPoiViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = FasesPoiMap.MaptoDTO(request);
            var _result = await _IFasesPoiRepository.ObtenerFasesPoi(dto);

            if (request.idFasesPoi == 0) throw new MreException("ingrese idFasesPoi");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerFasesPoiResponseViewModel>(_result);
        }
    }
}
