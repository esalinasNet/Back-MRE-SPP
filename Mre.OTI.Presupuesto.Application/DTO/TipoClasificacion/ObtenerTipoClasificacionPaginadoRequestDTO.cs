using Mre.OTIv1.Application.Base.DTO;

namespace Mre.OTIv1.Application.DTO.TipoClasificacion
{
    public class ObtenerTipoClasificacionPaginadoRequestDTO : Pagination
    {
        public string? nombre { get; set; }
        public int activo { get; set; }

    }
}
