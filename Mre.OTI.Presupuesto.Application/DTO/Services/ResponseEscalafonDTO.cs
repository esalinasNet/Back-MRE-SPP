using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.DTO.Services
{
    public class ResponseEscalafonDTO
    {
        public int idDetalleInformeEscalafonario { get; set; }
        public int idPostulacion { get; set; }
        public int? codigoCategoriaRemunerativa { get; set; }
        public int? codigoGrupoOcupacional { get; set; }
        public int codigoInformeEscalafonario { get; set; }
        public int flagsancionAdministrativa { get; set; }
        public string aniosTiempoServicio { get; set; }
        public string aniosUltimoCargo { get; set; }
        public string codigoPlaza { get; set; }
        public string regimenLaboral { get; set; }
        public string condicionLaboral { get; set; }
        public string situacionLaboral { get; set; }
        public string jornadaLaboral { get; set; }
        public bool aniossancionAdministrativa { get; set; }
        public string categoriaRemunerativa { get; set; }
        public string codigoModular { get; set; }
        public string centroTrabajo { get; set; }
        public string nivelCentroEstudio { get; set; }
        public string nombreDocumentoInformeEscalafonario { get; set; }
        public string numeroInformeEscalafonario { get; set; }
        public string fechaInformeEscalafonario { get; set; }
        public string documentoInformeEscalafonario { get; set; }
        public IEnumerable<InformeEscalafonarioEstudiosDTO> estudios { get; set; }
        public IEnumerable<InformeEscalafonarioMeritosDTO> meritos { get; set; }
        public IEnumerable<InformeEscalafonarioSancionesDTO> sanciones { get; set; }

        public int tiempoServicioOficialesAnio { get; set; }
        public int tiempoServicioOficialesDia { get; set; }
        public int tiempoServicioOficialesMes { get; set; }

        public int tiempoServicioUltimoCargoAnio { get; set; }
        public int tiempoServicioUltimoCargoDia { get; set; }
        public int tiempoServicioUltimoCargoMes { get; set; }

        public string numeroDocumentoIdentidad { get; set; }
        public int codigoDocumentoIdentidad { get; set; }

    }

    public class InformeEscalafonarioEstudiosDTO
    {
        public int anioFin { get; set; }
        public int anioInicio { get; set; }
        public string centroEstudios { get; set; }
        public string especialidad { get; set; }
        public string gradoAcademico { get; set; }
        public string grupoCarrera { get; set; }
        public string nivelEducativo { get; set; }
        public string situacionAcademica { get; set; }
        public string titulo { get; set; }
    }

    public class InformeEscalafonarioMeritosDTO
    {
        public string fechaMerito { get; set; }
        public string instancia { get; set; }
        public string merito { get; set; }
        public string tipoMerito { get; set; }
    }

    public class InformeEscalafonarioSancionesDTO
    {
        public string demerito { get; set; }
        public string fechaFin { get; set; }
        public string fechaInicio { get; set; }
        public string tipoDemerito { get; set; }
    }
}
