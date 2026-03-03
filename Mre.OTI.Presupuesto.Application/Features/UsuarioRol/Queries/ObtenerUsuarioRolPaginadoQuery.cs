using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.UsuarioRol;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UsuarioRol.Queries
{
    public class ObtenerUsuarioRolPaginadoQuery : IRequestHandler<ObtenerUsuarioRolPaginadoViewModel, dtUsuarioRolPaginadoResponseViewModel>
    {
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;

        private readonly IMapper _mapper;

        public ObtenerUsuarioRolPaginadoQuery(IUsuarioRolRepository IUsuarioRolRepository,
            IMapper mapper)
        {
            _IUsuarioRolRepository = IUsuarioRolRepository;
            _mapper = mapper;

        }
        public async Task<dtUsuarioRolPaginadoResponseViewModel> Handle(ObtenerUsuarioRolPaginadoViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
                var dto = UsuarioRolMap.MaptoDTO(request);

                if (request.paginaActual == 0) throw new MreException("ingrese paginaActual");
                if (request.tamanioPagina == 0) throw new MreException("tamanioPagina anio");

                var result = await _IUsuarioRolRepository.ObtenerUsuarioRolPaginado(dto);

                var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

                var datos = _mapper.Map<IEnumerable<ObtenerUsuarioRolPaginadoResponseViewModel>>(result);

                dtUsuarioRolPaginadoResponseViewModel data = new dtUsuarioRolPaginadoResponseViewModel
                {
                    draw = request.draw,
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsTotal,
                    data = datos
                };

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string HextoString(string InputText)
        {

            byte[] bb = Enumerable.Range(0, InputText.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(InputText.Substring(x, 2), 16))
                             .ToArray();
            //return Convert.ToBase64String(bb);
            char[] chars = new char[bb.Length / sizeof(char)];
            System.Buffer.BlockCopy(bb, 0, chars, 0, bb.Length);
            return new string(chars);
        }
    }
}
