using Mre.OTIv1.Application.Base.DTO;

namespace Mre.OTIv1.Application.DTO
{
    public class ObtenerPlazasVacantesPaginadoDTO : Pagination
    {
        public int IdCentroTrabajo { get; set; }
        public string codigoModular { get; set; }
        public string codigoPlaza { get; set; }

        public int idParametroInicial { get; set; }
        public int idCondicionPlaza { get; set; }

    }
}
