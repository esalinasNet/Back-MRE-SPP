using Mre.OTI.Presupuesto.Application.DTO.Seguridad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Repositories
{
    public interface ISeguridadRepository
    {
        Task<ObtenerAutorizacionResponseDTO> ObtenerAutorizacion(int idSistema, int idOpcion, int idPerfil, string accion);
        Task<IEnumerable<ObtenerOpcionResponseDTO>> ObtenerOpcion(string codigoSistema, int idPerfil);
        Task<IEnumerable<ObtenerPerfilOpcionResponseDTO>> ObtenerPerfilOpcion(string codigoSistema, int idPerfil);
    }
}
