using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Acciones.Queries
{
    public class ObtenerListadoAccionesQuery : IRequestHandler<ObtenerListadoAccionesViewModel, IEnumerable<ObtenerListadoAccionesResponseViewModel>>
    {
        readonly private IAccionesRepository _IAccionesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoAccionesQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesRepository IAccionesRepository, IMapper mapper)
        {
            _IAccionesRepository = IAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoAccionesResponseViewModel>> Handle(ObtenerListadoAccionesViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = AccionesMap.MaptoAccionesDTO(request);

                var result = await _IAccionesRepository.ObtenerListadoAcciones(dto);

                return result.Select(x => (ObtenerListadoAccionesResponseViewModel)AccionesMap.MaptoViewModelAcciones(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
