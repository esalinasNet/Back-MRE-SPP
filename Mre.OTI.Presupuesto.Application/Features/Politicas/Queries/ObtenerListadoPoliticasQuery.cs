using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Calendario.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Politicas.Queries
{
    public class ObtenerListadoPoliticasQuery : IRequestHandler<ObtenerListadoPoliticasViewModel, IEnumerable<ObtenerListadoPoliticasResponseViewModel>>
    {
        readonly private IPoliticasRepository _IPoliticasRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoPoliticasQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPoliticasRepository IPoliticasRepository, IMapper mapper)
        {
            _IPoliticasRepository = IPoliticasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoPoliticasResponseViewModel>> Handle(ObtenerListadoPoliticasViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = PoliticasMap.MaptoPoliticasDTO(request);

                var result = await _IPoliticasRepository.ObtenerListadoPoliticas(dto);

                return result.Select(x => (ObtenerListadoPoliticasResponseViewModel)PoliticasMap.MaptoViewModelPoliticas(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
