using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Programa.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Programa;
using Mre.OTI.Presupuesto.Application.Responses.SubPrograma;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Queries
{
    public class ObtenerSubProgramaQuery : IRequestHandler<ObtenerSubProgramaViewModel, ObtenerSubProgramaResponseViewModel>
    {
        readonly private ISubProgramaRepository _ISubProgramaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerSubProgramaQuery(IUsuarioRolRepository IIUsuarioRolRepository, ISubProgramaRepository ISubProgramaRepository, IMapper mapper)
        {
            _ISubProgramaRepository = ISubProgramaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerSubProgramaResponseViewModel> Handle(ObtenerSubProgramaViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            if (request.idSubPrograma == 0) throw new MreException("ingrese idSubPrograma");

            var result = await _ISubProgramaRepository.ObtenerSubPrograma(request.idSubPrograma);

            return _mapper.Map<ObtenerSubProgramaResponseViewModel>(result);
        }
    }
}
