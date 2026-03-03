using System;

namespace Mre.OTIv1.Application.DTO
{
    public class PrepararEtapasProcesoDTO
    {
        public long idProceso { get; set; }
        public int idMaestroProceso { get; set; }
        public int idEtapa { get; set; }
        public int idEstadoEtapa { get; set; }
        public string descripcionEtapa { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string ipCreacion { get; set; }
    }
}
