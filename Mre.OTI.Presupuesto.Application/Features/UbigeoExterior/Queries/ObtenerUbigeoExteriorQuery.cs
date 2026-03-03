using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    public class ObtenerUbigeoExteriorQuery : IRequestHandler<ObtenerUbigeoExteriorViewModel, ObtenerUbigeoExteriorResponseViewModel>
    {
        readonly private IUbigeoExteriorRepository _IUbigeoExteriorRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerUbigeoExteriorQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUbigeoExteriorRepository IUbigeoExteriorRepository, IMapper mapper)
        {
            _IUbigeoExteriorRepository = IUbigeoExteriorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerUbigeoExteriorResponseViewModel> Handle(ObtenerUbigeoExteriorViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idUbigeoExterior == 0) throw new MreException("ingrese idUbigeoExterior");

            var result = await _IUbigeoExteriorRepository.ObtenerUbigeoExterior(request.idUbigeoExterior);

            return _mapper.Map<ObtenerUbigeoExteriorResponseViewModel>(result);
        }
    }
}
