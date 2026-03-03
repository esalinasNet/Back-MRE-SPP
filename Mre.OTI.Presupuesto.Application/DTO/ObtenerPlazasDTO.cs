using Mre.OTIv1.Application.Base.DTO;
using System;

namespace Mre.OTIv1.Application.DTO
{
    public class ObtenerPlazasDTO : Pagination
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
    public class ObtenerPlazaRequestDTO : Pagination
    {

        public Int32 idPlaza { get; set; }

    }
    public class ObtenerPlazaResponseDTO
    {
        public Int32 ID_PLAZA { get; set; }
        public string TIPO_CARGO { get; set; }
        public string DESCRIPCION_CARGO { get; set; }
        public string CODIGO_PLAZA { get; set; }
        public string DESCRIPCION_JORNADA_LABORAL { get; set; }
        public string CONDICION { get; set; }
        public string DESCRIPCION_TIPO_PLAZA { get; set; }
        public DateTime VIGENCIA_INICIO { get; set; }
        public DateTime VIGENCIA_FIN { get; set; }
        public string DESCRIPCION_REGIMEN_LABORAL { get; set; }
        public string MOTIVO_VACANCIA { get; set; }
        public string DESCRIPCION_AREA_CURRICULAR { get; set; }

    }

}
