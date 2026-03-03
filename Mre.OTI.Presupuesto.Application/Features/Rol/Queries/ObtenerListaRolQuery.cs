using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CatalogoItem;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Rol;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Queries
{
    public class ObtenerListaRolQuery : IRequestHandler<ObtenerListaRolViewModel, IEnumerable<ObtenerListaRolResponseViewModel>>
    {
        readonly private IRolRepository _IRolRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListaRolQuery(IUsuarioRolRepository IIUsuarioRolRepository, IRolRepository IRolRepository, IMapper mapper)
        {
            _IRolRepository = IRolRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListaRolResponseViewModel>> Handle(ObtenerListaRolViewModel request, CancellationToken cancellationToken)
        {
            var result = await _IRolRepository.ObtenerListaRol();

            return result.Select(x => (ObtenerListaRolResponseViewModel)RolMap.MaptoViewModelLista(x));
        }
        
    }
}
