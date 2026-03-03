using Mre.OTIv1.Application.Base.DTO;
using System;

namespace Mre.OTIv1.Application.DTO
{
    public class ObtenerPlazaCuadroHoraPaginadoDTO : Pagination
    {
        public int IdTipoDocumentoIdentidad { get; set; }
        public string NumeroDocumento { get; set; }
        public int IdAreaCurricular { get; set; }
        public int IdEstado { get; set; }
        public int IdProceso { get; set; }
        public int idParametroInicial { get; set; }

        public int idSituacionDistribucion { get; set; }

        public int idCondicionPlaza { get; set; }
        public string codigoPlaza { get; set; }
        public string codigoModular { get; set; }
    }
    public class PlazaCuadroHoraPorParametroRequestDTO
    {
        public int idParametroInicial { get; set; }

    }
    public class ObtenerPlazaCuadroHoraAsignadaPaginadoDTO : Pagination
    {
        public int idPlazaCuadroHora { get; set; }
        public int idGrado1 { get; set; }
        public int idGrado2 { get; set; }
        public int idGrado3 { get; set; }
        public int idGrado4 { get; set; }
        public int idGrado5 { get; set; }


    }
    public class ObtenerPlazaCuadroHoraPendienteDistribuirPaginadoDTO : Pagination
    {
        public int idParametroInicial { get; set; }
        public int idGrado1 { get; set; }
        public int idGrado2 { get; set; }
        public int idGrado3 { get; set; }
        public int idGrado4 { get; set; }
        public int idGrado5 { get; set; }
    }
    public class ObtenerPlazaCuadroHoraPendienteDistribuirDTO
    {
        public int registro { get; set; }
        public int totalRegistro { get; set; }
        public int idAreaCurricular { get; set; }
        public string descripcionAreaCurricular { get; set; }
        public int primero { get; set; }
        public int segundo { get; set; }
        public int tercero { get; set; }
        public int cuarto { get; set; }
        public int quinto { get; set; }
    }
    public class PlazaCuadroHoraServidorRequestDTO
    {
        public int idParametroInicial { get; set; }
        public int idTipoPlazaOrganica { get; set; }
        public int idCondicionOcupada { get; set; }
        public int idEstadoPlazaAprobada { get; set; }
        public int idTipoCargoDirectivo { get; set; }
        public int idTipoCargoJerarquico { get; set; }
        public int idTipoCargoDocente { get; set; }
        public int idRegimenLaboral { get; set; }
        public int idEstadoDistribucion { get; set; }
        public int idCargoDirectorIE { get; set; }
        public int idCargoSubDirectorIE { get; set; }
        public int idCargoCoordinadorAcademico { get; set; }
        public int idCargoCoordinadorTutoriaOrientacion { get; set; }
        public int idCargoCoordinadorPedagogico { get; set; }
        public int idCargoJefeLaboratorio { get; set; }
        public int idCargoJefeTaller { get; set; }
        public int idCargoProfesor { get; set; }
        public int idCargoProfesorEducacionFisica { get; set; }
        public int idCuadroHoraServidorPublico { get; set; }





    }
    public class ServidorPublicoPlazaResponseDTO
    {
        public int ORDEN { get; set; }
        public int CATEGORIA_REMUNERATIVA { get; set; }
        public int ID_CUADRO_HORA_SERVIDOR_PUBLICO { get; set; }
        public int CODIGO_CATALOGO_ITEM_TIPO_CARGO { get; set; }
        public string TIPO_CARGO { get; set; }
        public int ID_SERVIDOR_PUBLICO { get; set; }
        public int ID_TIPO_CARGO { get; set; }

        public string SERVIDOR_PUBLICO { get; set; }
        public int TIEMPO_SERVICIO_AREA_IIEE { get; set; }
        public int TIEMPO_SERVICIO { get; set; }
    }

    public class ServidorPublicoCargarPlazaResponseDTO
    {
        public int idServidorPublico { get; set; }
        public int idTipoDocumento { get; set; }
        public int codigoTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }

        public int idPlaza { get; set; }
        public int orden { get; set; }

        public string tiempoServicioAreaIIEE { get; set; }
        public string tiempoServicio { get; set; }

        public int tiempoServicioOficialesAnio { get; set; }
        public int tiempoServicioOficialesDia { get; set; }
        public int tiempoServicioOficialesMes { get; set; }

        public int tiempoServicioUltimoCargoAnio { get; set; }
        public int tiempoServicioUltimoCargoDia { get; set; }
        public int tiempoServicioUltimoCargoMes { get; set; }

    }
    public class ObtenerServidorPublicoPorIdCuadroHoraResponseDTO
    {
        public int idServidorPublico { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string nombres { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string fechaNacimientoStr { get { return this.fechaNacimiento.HasValue ? this.fechaNacimiento.Value.ToString("dd/MM/yyyy") : string.Empty; } }
        public int? idGenero { get; set; }
        public string genero { get; set; }
        public int? tiempoServiciosOficiales { get; set; }
        public int? tiempoServiciosUltimoCargo { get; set; }
        public string documentoIdentidad { get; set; }
        public int horaSesionAprendizaje { get; set; }

        public int saldoHoraSesionAprendizaje { get; set; }

        public int codigoEstadoValidacion { get; set; }
        public int codigoSituacionValidacion { get; set; }
        public int codigoEstadoDistribucion { get; set; }
        public int codigoSituacionDistribucion { get; set; }
        public int codigoResultadoFinal { get; set; }
        public string jornadaLaboral { get; set; }


    }
    public class ObtenerPlazaCuadroHoraResultadoFinalResponseDTO
    {
        public int idCuadroHoraServidorPublico { get; set; }
        public string tipoCargo { get; set; }
        public string cargo { get; set; }
        public string areaCurricular { get; set; }
        public string codigoPlaza { get; set; }
        public string jornadaLaboral { get; set; }
        public string condicion { get; set; }
        public string numeroDocIdentidad { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string especialidad { get; set; }
        public string categoriaRenumerativa { get; set; }
        public int tiempoServicioIIEE { get; set; }
        public int tiempoServicio { get; set; }
        public string estado { get; set; }
        public int idPlaza { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
        public DateTime fechaCorte { get; set; }
        public int idServidorPublico { get; set; }
        public int idParametroInicial { get; set; }
        public int horaLectiva { get; set; }
        public int horaNoLectiva { get; set; }
        public bool tieneReclamo { get; set; }
        public string detalleReclamo { get; set; }
    }

    public class ObtenerCantidadRegistrosPorEstadoDistribucionRequestDTO
    {

        public int idEstadoDistribucion { get; set; }
        public int idParametroInicial { get; set; }
        public int idSituacionDistribucion { get; set; }
    }
    public class ObtenerCantidadRegistrosPorValidacionRequestDTO
    {

        public int idEstadoValidacion { get; set; }
        public int idParametroInicial { get; set; }
        public int idSituacionValidacion { get; set; }
    }
    public class ObtenerTotalizadosDistribucionRequestDTO
    {
        public int idParametroInicial { get; set; }
        //public int idUnidadEjecutora { get; set; }
        //public int idSubUnidadEjecutora { get; set; }
        //public int idInstitucionEducativa { get; set; }
        //public int anio { get; set; }
    }

    public class ObtenerTotalizadosDistribucionResponseDTO
    {
        public int totalHoraDistribuida { get; set; }
        public int totalHoraLectiva { get; set; }
        public int pendiente
        {
            get
            {
                return this.totalHoraLectiva - this.totalHoraDistribuida;
            }
        }

    }
    public class PlazaCuadroHoraResponseDTO
    {
        public int idCuadroHoraServidorPublico { get; set; }
        public int idEtapaProceso { get; set; }
        public int idProceso { get; set; }
        public int idServidorPublico { get; set; }
        public int idTipoPlaza { get; set; }
        public int idTipoCargo { get; set; }
        public int idCargo { get; set; }
        public int idJornadaLaboral { get; set; }
        public int idCondicionLaboral { get; set; }
        public int idPersona { get; set; }
        public int idCategoriaRemunerativa { get; set; }
        public int idMotivoNoPublicacion { get; set; }
        public int idRegimenContrato { get; set; }
        public int idParametroInicial { get; set; }
        public int idEstadoValidacion { get; set; }
        public int idSituacionValidacion { get; set; }
        public int idEstadoDistribucion { get; set; }
        public int idSituacionDistribucion { get; set; }

        public int idResultadoFinal { get; set; }
        public int orden { get; set; }
        public int tiempoServicioAreaIIEE { get; set; }
        public int tiempoServicio { get; set; }
        public int lenguaOriginariaEIB { get; set; }
        public DateTime? fechaCorte { get; set; }
        public int visibleFormacionAcademica { get; set; }
        public int totalExperienciaEspecifica { get; set; }
        public string detalleNoPublicacion { get; set; }
        public DateTime? fechaMigracion { get; set; }
        public int? idPlaza { get; set; }
        public int idEstadoPlaza { get; set; }

        public bool conReclamo { get; set; }
        public string detalleReclamo { get; set; }
        public string anotacionesObservacion { get; set; }




    }
    public class PlazaCuadroHoraReaperturarDTO
    {
        public int idParametroInicial { get; set; }
        public int idResultadoFinal { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string usuarioModificacion { get; set; }
        public string ipModificacion { get; set; }

    }
    public class PlazaCuadroHoraResponseIncorporacionDTO
    {

        public int ID_CUADRO_HORA_SERVIDOR_PUBLICO { get; set; }
        public string TIPO_CARGO { get; set; }
        public string DESCRIPCION_CARGO { get; set; }
        public string DESCRIPCION_AREA_CURRICULAR { get; set; }
        public string CODIGO_PLAZA { get; set; }
        public string DESCRIPCION_JORNADA_LABORAL { get; set; }
        public string CONDICION { get; set; }
        public string NUMERO_DOCUMENTO_IDENTIDAD { get; set; }
        public int CODIGO_TIPO_DOCUMENTO_IDENTIDAD { get; set; }

        public string NOMBRES { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public string ESPECIALIDAD { get; set; }
        public string DESCRIPCION_CATEGORIA_REMUNERATIVA { get; set; }
        public int TIEMPO_SERVICIO_AREA_IIEE { get; set; }
        public int TIEMPO_SERVICIO { get; set; }
        public string SITUACION_VALIDACION { get; set; }
        public int ID_PLAZA { get; set; }
        public int registro { get; set; }
        public int totalRegistro { get; set; }
        public DateTime? FECHA_CORTE { get; set; }
        public int ID_SERVIDOR_PUBLICO { get; set; }
        public int ID_PARAMETRO_INICIAL { get; set; }
        public string TIEMPO_SERVICIO_AREA_IIEE_TEXTO { get; set; }
        public string TIEMPO_SERVICIO_TEXTO { get; set; }
    }

}
