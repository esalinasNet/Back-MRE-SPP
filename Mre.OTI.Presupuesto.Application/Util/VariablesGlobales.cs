namespace Mre.OTI.Presupuesto.Application.Util
{
    public class VariablesGlobales
    {
        public enum TablaCatalogo
        {
            /*INICIO CATALOGO MRE*/
            CLASIFICACION_DOCUMENTO = 14,
            TIPO_DOCUMENTO_AUTORIZACION = 1022,
            AREA_DOCUMENTO = 1021,
            ESTADO_DOCUMENTO = 1024,
            ANIOS = 421,

            PAIS = 12,            
            CARGO = 8,
            CATEGORIA = 7,
            STATUS = 6,
            TIPO_SOLICITUD = 2,
            TIPO_OBSERVACION = 10,
            TIPO_BAJA = 18,
            GRUPO_PAIS = 19,
            TIPO_ORIGEN_SOL = 30,
            TIPO_ENTIDADES = 37,
            //esv
            TIPO_DOCUMENTO_IDENTIDAD = 1,
            ESTADO_CIVIL = 3,
            TIPO_GENERO = 2,



        }
        //public enum TablaTipoDocumentoProyectoMcc
        //{
        //    DECRETO_SUPREMO = 1,
        //    RESOLUCION_MINISTERIAL = 2

        //}
        //public enum TablaEstadosProyectoMcc
        //{
        //    INICIADO = 1,
        //    OBSERVADO = 2,
        //    //APROBADO=3,
        //    ANULADO=4,

        //    POR_COMPLETAR = 5,
        //    PENDIENTE_APROBACION = 6,
        //    COMPLETADO = 7,



        //    POR_APROBAR=1,
        //    APROBADO=2,
        //    RECHAZADO=3,

        //}
        //public enum TablaEstadosProyectoEo
        //{
        //    INICIADO = 1,
        //    OBSERVADO = 2,
        //    //APROBADO=3,
        //    ANULADO = 4,

        //    POR_COMPLETAR = 5,
        //    PENDIENTE_APROBACION = 6,
        //    COMPLETADO = 7,



        //    POR_APROBAR = 1,
        //    APROBADO = 2,
        //    RECHAZADO = 3,

        //}
        //public enum TablaEstadosEjecucion
        //{
        //    POR_INICIAR = 1,
        //    INICIADO = 2,
        //    FINALIZADO = 3,

        //}
        //public enum TablaTipoPeso
        //{
        //    PESO_PROCENTAJE=1,
        //    VALOR=2
        //}
        //public enum TablaEstadosFormato
        //{
        //    POR_CONFIGURAR = 1,
        //    EN_CONFIGURACION = 2,
        //    CONFIGURACION_FINALIZADA = 3
        //}
        //public enum TablaCodigoFormato
        //{
        //    AUTOEVALUACION=1,
        //    EVAL180=3,
        //    EVAL90=2
        //}
        public enum TablaPaises
        {
            PERU = 1,
        }
        public enum TablaEstadosEvaluacion
        {
            INICIADO = 1,
            POR_COMPLETAR= 2,
            FINALIZADO = 3,
            PROCESADO=4
        }

        public enum TablaRol
        {
            TODOS = 0, /*UTILIZADO PARA LA VALIDACION DEL ROL PARA ACCEDER AL RECURSO. 0 SIGNIFICA QUE TODOS PUEDEN ACCEDER*/
            ANALISTA_OGTH = 1,
            CONSULTAS = 2,
            AUXILIAR_OGTH = 3,
            PERSONAL = 4,
        }

        public enum TablaTipoPregunta
        {
            ABIERTA = 1,
            CERRADA = 2,
            ESCALA_LIKCERT = 3
        }
        public enum TablaEstadoProcesarCargaPersonal
        {
            POR_PROCESAR = 1,
            PROCESADO=2
        }
        public enum TablaEstadoCivil
        {
            CASADO = 1,
            SOLTERO = 2
        }
        public enum TablaTipoDocumentoIdentidad
        {
            DNI = 1,
            PASAPORTE = 2
        }
        public enum TablaNivelCc
        {
            GERENCIA = 1
        }
        public enum CodigoTipoEnvioCorreo
        {
            PARA_LIMA = 1,
            PARA_EXTERIOR = 2,
            PARA_OTROS = 3,
        }
       public enum TipoComboEvaluaciones
        {
            PARA_EVAL_180=1,
            PARA_EVAL_90=2,
            PARA_AUTO_EVAL=3
        }

        public enum Anio
        {

        }

        public enum Funcion
        {

        }

    }
}