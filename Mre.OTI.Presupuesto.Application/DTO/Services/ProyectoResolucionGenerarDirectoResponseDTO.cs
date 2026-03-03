using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.DTO.Services
{
    //public class ProyectoResolucionGenerarDirectoResponseDTO
    //{
    //    public string codigoProyectoResolucion { get; set; }
    //    public string documentoProyectoResolucion { get; set; }
    //    public int codigoAccionGrabada { get; set; }
    //    public string codigoPlaza { get; set; }
    //    public int itemPlaza { get; set; }
    //    public long? codigoServidorPublico { get; set; }
    //    public int? codigoTipoDocumentoIdentidad { get; set; }
    //    public string numeroDocumentoIdentidad { get; set; }
    //}

    public class ProyectoResolucionGenerarDirectoResponseDTO
    {
        public string codigoProyectoResolucion { get; set; }
        public string documentoProyectoResolucion { get; set; }
        public string numeroProyectoResolucion { get; set; }
        public object data { get; set; }
        public List<string> messages { get; set; }
        public bool result { get; set; }
        public IEnumerable<AccionProcesadasResponse> accionProcesadas { get; set; }
    }

    public class AccionProcesadasResponse
    {
        public string codigoPlaza { get; set; }
        public string codigoAccionGrabada { get; set; }
    }
}
