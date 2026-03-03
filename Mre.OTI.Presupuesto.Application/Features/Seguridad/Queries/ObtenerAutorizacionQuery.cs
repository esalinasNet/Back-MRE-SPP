using AutoMapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Seguridad;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.Seguridad.Queries
{

    public class ObtenerAutorizacionQuery : IRequestHandler<ObtenerAutorizacionViewModel, ObtenerAutorizacionResponseViewModel>
    {
        readonly private ISeguridadRepository _seguridadRepository;
        private readonly IMapper _mapper;

        public ObtenerAutorizacionQuery(ISeguridadRepository seguridadRepository, IMapper mapper)
        {
            _mapper = mapper;
            _seguridadRepository = seguridadRepository;
        }

        public async Task<ObtenerAutorizacionResponseViewModel> Handle(ObtenerAutorizacionViewModel request, CancellationToken cancellationToken)
        {
            try
            {    
                var result = await _seguridadRepository.ObtenerAutorizacion(request.IdSistema, request.IdOpcion, request.IdPerfil, request.Accion);
                ObtenerAutorizacionResponseViewModel authorized = new ObtenerAutorizacionResponseViewModel
                {
                    IsAuthorized = result != null
                };

                return authorized;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
