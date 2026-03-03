namespace Mre.OTI.Presupuesto.Application.DTO.Services
{
    public class InformeEscalafonarioMultipleRequestDTO
    {
        public int idTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string numeroInformeEscalafonario { get; set; }
        public string sede { get; set; }
        public string tipoSede { get; set; }
        public int anio { get; set; }
    }
}
