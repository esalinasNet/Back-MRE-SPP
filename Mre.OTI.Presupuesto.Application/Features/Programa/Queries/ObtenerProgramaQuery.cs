using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Programa;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Programa.Queries
{
    public class ObtenerProgramaQuery : IRequestHandler<ObtenerProgramaViewModel, ObtenerProgramaResponseViewModel>
    {
        readonly private IProgramaRepository _IProgramaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerProgramaQuery(IUsuarioRolRepository IIUsuarioRolRepository, IProgramaRepository IProgramaRepository, IMapper mapper)
        {
            _IProgramaRepository = IProgramaRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _mapper = mapper;
        }

        public async Task<ObtenerProgramaResponseViewModel> Handle(ObtenerProgramaViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idPrograma == 0) throw new MreException("ingrese idPrograma");

            var result = await _IProgramaRepository.ObtenerPrograma(request.idPrograma);

            return _mapper.Map<ObtenerProgramaResponseViewModel>(result);
        }
    }
}
