using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Responses.ObjetivosInstitucionales;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.ObjetivosInstitucionales.Queries
{
    public class ObtenerListadoObjetivosInstitucionalesQuery : IRequestHandler<ObtenerListadoObjetivosInstitucionalesViewModel, IEnumerable<ObtenerListadoObjetivosInstitucionalesResponseViewModel>>
    {
        readonly private IOjetivosInstitucionalesRepository _IOjetivosInstitucionalesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoObjetivosInstitucionalesQuery(IUsuarioRolRepository IIUsuarioRolRepository, IOjetivosInstitucionalesRepository IOjetivosInstitucionalesRepository, IMapper mapper)
        {
            _IOjetivosInstitucionalesRepository = IOjetivosInstitucionalesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoObjetivosInstitucionalesResponseViewModel>> Handle(ObtenerListadoObjetivosInstitucionalesViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ObjetivosInstitucionalesMap.MaptoObjetivosInstitucionalesDTO(request);

                var result = await _IOjetivosInstitucionalesRepository.ObtenerListadoObjetivosInstitucionales(dto);

                return result.Select(x => (ObtenerListadoObjetivosInstitucionalesResponseViewModel)ObjetivosInstitucionalesMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
