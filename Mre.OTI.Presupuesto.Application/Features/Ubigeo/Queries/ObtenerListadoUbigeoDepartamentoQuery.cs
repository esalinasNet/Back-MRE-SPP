using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerListadoUbigeoDepartamentoQuery : IRequestHandler<ObtenerListadoUbigeoDepartamentoViewModel, IEnumerable<ObtenerListadoUbigeoDepartamentoResponseViewModel>>
    {
        private readonly IUbigeoRepository _IUbigeoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoUbigeoDepartamentoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IUbigeoRepository IUbigeoRepository,
            IMapper mapper)
        {
            _IUbigeoRepository = IUbigeoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoUbigeoDepartamentoResponseViewModel>> Handle(ObtenerListadoUbigeoDepartamentoViewModel request, CancellationToken cancellationToken)
        {
            var result = await _IUbigeoRepository.ObtenerListadoUbigeoDepartamento();

            return result.Select(x => (ObtenerListadoUbigeoDepartamentoResponseViewModel)UbigeoMap.MaptoViewModelDepartamento(x));
        }
    }
}
