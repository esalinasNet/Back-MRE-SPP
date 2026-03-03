using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.UsuarioRol;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Queries
{
    public class ObtenerUsuarioRolQuery : IRequestHandler<ObtenerUsuarioRolViewModel, ObtenerUsuarioRolResponseViewModel>
    {
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        private readonly IMapper _mapper;
        public ObtenerUsuarioRolQuery(IUsuarioRolRepository IUsuarioRolRepository,  IMapper mapper)
        {
            _IUsuarioRolRepository = IUsuarioRolRepository;
               _mapper = mapper;
        }
        public async Task<ObtenerUsuarioRolResponseViewModel> Handle(ObtenerUsuarioRolViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                if (request.idUsuarioRol == 0) throw new MreException("ingrese idUsuarioRol");
                var result = await _IUsuarioRolRepository.ObtenerUsuarioRol(request.idUsuarioRol, Constantes.SISTEMA.KEY_ENCRYPT_LOGIN);
                
                return _mapper.Map<ObtenerUsuarioRolResponseViewModel>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
