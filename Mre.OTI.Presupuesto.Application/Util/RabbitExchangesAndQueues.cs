namespace Mre.OTI.Presupuesto.Application.Util
{
    public static class RabbitExchangesAndQueues
    {
        public struct TipoPlaza
        {
            public const string Exchange = "rrhh-plazas-registro-tipoplaza-fanout-exchange";
            public const string Queue = "rrhh-personal-gestion-procesos-tipoplaza-queue";
        }
        public struct CuadroHora
        {
            public const string RABBIT_DIRECT_REGISTRO_PROCESOS = "rrhh-personal-procesos-gestion-proceso-direct-exchange";
            public const string RABBIT_QUEUE_REGISTRO_PROCESOS = "rrhh-personal-cuadrohoras-proceso-queue";
            //public const string RABBIT_QUEUE_REGISTRO_PROCESOS_TEST = "rrhh-personal-cuadrohoras-proceso-queue-test";

            public const string RABBIT_DIRECT_REGISTRO_ALCANCE_CRONOGRAMA = "rrhh-personal-procesos-gestion-alcanceproceso-direct-exchange";
            public const string RABBIT_QUEUE_REGISTRO_ALCANCE_CRONOGRAMA = "rrhh-personal-cuadrohoras-alcanceproceso-queue";
        }
        public struct Proceso
        {
            public const string RABBIT_DIRECT_REGISTRO_PROCESOS = "rrhh-personal-procesos-gestion-proceso-direct-exchange";
            public const string RABBIT_QUEUE_REGISTRO_PROCESOS = "rrhh-personal-contratacion-proceso-queue";
            public const string RABBIT_QUEUE_REGISTRO_PROCESOS_TEST = "rrhh-personal-contratacion-proceso-queue-test";

            public const string RABBIT_DIRECT_REGISTRO_ALCANCE_CRONOGRAMA = "rrhh-personal-procesos-gestion-alcanceproceso-direct-exchange";
            public const string RABBIT_QUEUE_REGISTRO_ALCANCE_CRONOGRAMA = "rrhh-personal-procesos-gestion-alcanceproceso-direct-queue";
        }
        public struct Aprobacion
        {
            public const string RABBIT_APROBACIONES_REQUEST_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-request-direct-exchange";
            public const string RABBIT_APROBACIONES_REQUEST_QUEUE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-request-queue";

            public const string RABBIT_APROBACIONES_RESPONSE_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-response-direct-exchange";
            public const string RABBIT_APROBACIONES_RESPONSE_QUEUE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-response-queue";

            public const string RABBIT_APROBACION_RESPONSE_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-respuesta-response-fanout-exchange";
            //public const string RABBIT_APROBACION_RESPONSE_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-response-direct-exchange";


            //public const string RABBIT_APROBACIONES_REQUEST_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-request-direct-exchange";
            //public const string RABBIT_APROBACIONES_REQUEST_QUEUE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-request-queue";

            public const string RABBIT_APROBACIONES_PROCESOCREADO_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-procesocreado-response-fanout-exchange";
            public const string RABBIT_APROBACIONES_PROCESOCREADO_QUEUE = "rrhh-negocio-comunes-aprobaciones-procesocreado-adecuacion-response-queue";

            //public const string RABBIT_APROBACIONES_RESPONSE_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-response-direct-exchange";
            //public const string RABBIT_APROBACIONES_RESPONSE_QUEUE = "rrhh-negocio-comunes-aprobaciones-backend-aprobar-response-queue";

            //public const string RABBIT_APROBACION_RESPONSE_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-respuesta-response-fanout-exchange";

            public const string RABBIT_APROBACION_FINAL_EXCHANGE = "rrhh-negocio-comunes-aprobaciones-respuestafinal-response-fanout-exchange";

            //rrhh-negocio-comunes-aprobaciones-respuestafinal-response-fanout-exchange
            public const string RABBIT_APROBACION_FINAL_QUEUE = "rrhh-negocio-comunes-aprobaciones-respuestafinal-response-fanout-queue";






        }
    }
}
