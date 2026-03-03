using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.SubPrograma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Queries
{
    public class ObtenerListadoSubProgramaFuncionQuery : IRequestHandler<ObtenerListadoSubProgramaViewModel, IEnumerable<ObtenerListadoSubProgramaResponseViewModel>>
    {
        private readonly ISubProgramaRepository _ISubProgramaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoSubProgramaFuncionQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ISubProgramaRepository ISubProgramaRepository,
            IMapper mapper)
        {
            _ISubProgramaRepository = ISubProgramaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoSubProgramaResponseViewModel>> Handle(ObtenerListadoSubProgramaViewModel request, CancellationToken cancellationToken)
        {
            var result = await _ISubProgramaRepository.ObtenerListadoSubPrograma();

            return result.Select(x => (ObtenerListadoSubProgramaResponseViewModel)SubProgramaMap.MaptoViewModel(x));

            throw new NotImplementedException();
        }
    }
}
