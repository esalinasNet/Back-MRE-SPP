using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Persona.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Persona;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Funcion.Queries
{
    internal class ObtenerFuncionQuery : IRequestHandler<ObtenerFuncionViewModel, ObtenerFuncionResponseViewModel>
    {
        readonly private IFuncionRepository _IFuncionRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerFuncionQuery(IUsuarioRolRepository IIUsuarioRolRepository, IFuncionRepository IFuncionRepository, IMapper mapper)
        {
            _IFuncionRepository = IFuncionRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _mapper = mapper;
        }

        public async Task<ObtenerFuncionResponseViewModel> Handle(ObtenerFuncionViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idFuncion == 0) throw new MreException("ingrese idFuncion");

            var result = await _IFuncionRepository.ObtenerFuncion(request.idFuncion);

            return _mapper.Map<ObtenerFuncionResponseViewModel>(result);
        }
    }
}
