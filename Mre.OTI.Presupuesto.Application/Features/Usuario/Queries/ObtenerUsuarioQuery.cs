using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;
using Mre.OTI.Presupuesto.Application.Util;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{
    public class ObtenerUsuarioQuery : IRequestHandler<ObtenerUsuarioViewModel, ObtenerUsuarioResponseViewModel>
    {
        readonly private IUsuarioRepository _IUsuarioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerUsuarioQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUsuarioRepository IUsuarioRepository, IMapper mapper)
        {
            _IUsuarioRepository = IUsuarioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<ObtenerUsuarioResponseViewModel> Handle(ObtenerUsuarioViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
            if (request.idUsuario == 0) throw new MreException("ingrese idUsuario");
            var result = await _IUsuarioRepository.ObtenerUsuario(request.idUsuario,Constantes.SISTEMA.KEY_ENCRYPT_LOGIN);

            return _mapper.Map<ObtenerUsuarioResponseViewModel>(result);
        }
    }
}
