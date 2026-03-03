using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Politicas.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries
{
    public class ObtenerListadoObjetivosQuery : IRequestHandler<ObtenerListadoObjetivosViewModel, IEnumerable<ObtenerListadoObjetivosResponseViewModel>>
    {
        readonly private IOjetivosRepository _IOjetivosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoObjetivosQuery(IUsuarioRolRepository IIUsuarioRolRepository, IOjetivosRepository IOjetivosRepository, IMapper mapper)
        {
            _IOjetivosRepository = IOjetivosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoObjetivosResponseViewModel>> Handle(ObtenerListadoObjetivosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ObjetivosMap.MaptoObjetivosDTO(request);

                var result = await _IOjetivosRepository.ObtenerListadoObjetivos(dto);

                return result.Select(x => (ObtenerListadoObjetivosResponseViewModel)ObjetivosMap.MaptoViewModelObjetivos(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
