using Mre.OTI.Presupuesto.Domain.Base;

namespace Mre.OTI.Presupuesto.Domain.Entities
{
    public class DocumentosAdjuntos : Auditoria
    {
        public int ID_DOCUMENTO_ADJUNTO { get; set; }
        public int ID_TIPO_DOCUMENTO { get; set; }
        public int? ID_SUB_TIPO_DOCUMENTO { get; set; }
        public int ID_SOLICITUD { get; set; }
        public string RUTA_DOCUMENTO { get; set; }
        public int? ID_ESTADO_DOCUMENTO { get; set; }
        public string? DETALLE { get; set; }
        public decimal? IMPORTE { get; set; }
        public string COMENTARIO_OBS { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }

    }
}
