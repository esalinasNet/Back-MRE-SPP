using Mre.OTIv1.Application.Base.DTO;

namespace Mre.OTIv1.Application.DTO
{
    public class ObtenerProcesoPaginadoDTO : Pagination
    {
        public int anio { get; set; }
        public int? idRegimenLaboral { get; set; }
        public int? idEstado { get; set; }
        public int? idProceso { get; set; }
        public int? idTipoProceso { get; set; }

        public string codigoCentroTrabajo { get; set; }

    }
}
