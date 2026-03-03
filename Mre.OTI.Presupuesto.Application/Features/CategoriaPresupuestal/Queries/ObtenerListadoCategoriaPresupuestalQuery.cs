using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CategoriaPresupuestal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Util;

namespace Mre.OTI.Presupuesto.Application.Features.CategoriaPresupuestal.Queries
{
    public class ObtenerListadoCategoriaPresupuestalQuery : IRequestHandler<ObtenerListadoCategoriaPresupuestalViewModel, IEnumerable<ObtenerListadoCategoriaPresupuestalResponseViewModel>>
    {
        readonly private ICategoriaPresupuestalRepository _ICategoriaPresupuestalRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoCategoriaPresupuestalQuery(IUsuarioRolRepository IIUsuarioRolRepository, ICategoriaPresupuestalRepository ICategoriaPresupuestalRepository, IMapper mapper)
        {
            _ICategoriaPresupuestalRepository = ICategoriaPresupuestalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoCategoriaPresupuestalResponseViewModel>> Handle(ObtenerListadoCategoriaPresupuestalViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = CategoriaPresupuestalMap.MaptoCategoriaPresupuestalDTO(request);

                var result = await _ICategoriaPresupuestalRepository.ObtenerListadoCategoriaPresupuestal(dto);

                return result.Select(x => (ObtenerListadoCategoriaPresupuestalResponseViewModel)CategoriaPresupuestalMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
