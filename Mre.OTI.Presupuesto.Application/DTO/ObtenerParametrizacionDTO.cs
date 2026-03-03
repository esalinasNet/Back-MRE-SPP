using Mre.OTIv1.Application.Base.DTO;

namespace Mre.OTIv1.Application.DTO
{
    public class ObtenerParametrizacionDTO : Pagination
    {
        public string anio { get; set; }
        public string codigoModular { get; set; }
        public string descripcionInstitucion { get; set; }
        public string descripcionModalidad { get; set; }

        public string descripcionUbigeo { get; set; }
        public int? totalHoraAsignadaUnidadEjecutora { get; set; }
        public int? totalHoraAsignadaIIEE { get; set; }
        public int? totalSadoHoraAsignadaIIEE { get; set; }

    }
    public class ObtenerParametroInicialRequestDTO
    {

        public int idProceso { get; set; }
        public int idEtapaProceso { get; set; }
        public int idCentrotrabajo { get; set; }
        public int idModalidadEducativa { get; set; }
        public int idNivelEducativo { get; set; }
        public int idModalidadServicioEducativo { get; set; }
        public int idUnidadEjecutora { get; set; }


    }
    public class ObtenerParametroInicialPorIdRequestDTO
    {


        public int idParametroInicial { get; set; }


    }
    public class ObtenerParametroInicialPorCentroTrabajoRequestDTO
    {


        public int idCentroTrabajo { get; set; }
        public int idEtapaProceso { get; set; }


    }
    public class ObtenerParametroInicialPorCentroTrabajoAnioRequestDTO
    {


        public int idCentroTrabajo { get; set; }
        public int anio { get; set; }


    }

    public class ParametroInicialCambiarEstadoDTO
    {

        public int idParametroInicial { get; set; }
        public int idEstadoCuadroHoras { get; set; }
        public string ipModificacion { get; set; }
        public string usuarioModificacion { get; set; }
    }
}
