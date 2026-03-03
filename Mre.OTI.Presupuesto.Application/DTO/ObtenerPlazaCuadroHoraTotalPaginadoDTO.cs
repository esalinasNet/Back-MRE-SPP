using Mre.OTIv1.Application.Base.DTO;

namespace Mre.OTIv1.Application.DTO
{
    public class ObtenerPlazaCuadroHoraTotalPaginadoDTO : Pagination
    {
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodigoModular { get; set; }
        public string CodigoPlaza { get; set; }
        public int IdAreaCurricular { get; set; }
        public int idParametroInicial { get; set; }
        public int idSituacionDistribucion { get; set; }
        /// <summary>
        /// DEFAULT PARA PLAZA OCUPADA
        /// </summary>
        public int idCondicionPlaza { get; set; }

    }
}
