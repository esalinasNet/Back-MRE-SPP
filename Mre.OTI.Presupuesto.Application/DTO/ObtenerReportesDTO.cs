namespace Mre.OTIv1.Application.DTO
{
    internal class ObtenerReportesDTO
    {
    }

    public class ReporteAnexo1_VariablesDTO
    {
        public string TITTLE { get; set; }
        public int PRIMER { get; set; }
        public int SEGUNDO { get; set; }
        public int TERCERO { get; set; }
        public int CUARTO { get; set; }
        public int QUINTO { get; set; }

    }

    public class ReporteAnexo1_CargosDTO
    {
        public string DESCRIPCION_CARGO { get; set; }
        public string ABREVIATURA_REGIMEN_LABORAL { get; set; }
        public string DESCRIPCION_AREA_DESEMPENIO_LABORAL { get; set; }
        public string CODIGO_PLAZA { get; set; }
        public int ID_CENTRO_TRABAJO { get; set; }
        public string CODIGO_CENTRO_TRABAJO { get; set; }
        public string DESCRIPCION_JORNADA_LABORAL { get; set; }
        public int HORA_DICTADO { get; set; }
        public int registro { get; set; }

    }
    public class ReporteAnexo1_CargosRequestDTO
    {

        public string codigoCentroTrabajo { get; set; }
        public int idParametroInicial { get; set; }
        public int idRegimenLaboral { get; set; }
        public int idCondicionPlaza { get; set; }



    }

    public class ReporteAnexo2RequestDTO
    {
        public int idParametroInicial { get; set; }
        public int idGrado1 { get; set; }
        public int idGrado2 { get; set; }
        public int idGrado3 { get; set; }
        public int idGrado4 { get; set; }
        public int idGrado5 { get; set; }

    }
    public class ReporteAnexo2HLDDTO
    {
        public string item { get; set; }
        public string descripcionAreaCurricular { get; set; }
        public int totalHLD { get; set; }
    }
    public class ReporteAnexo2DTO
    {
        public int idAreaCurricular { get; set; }
        public string descripcionAreaCurricular { get; set; }

        private int _totalPrimero;
        public int totalPrimero
        {
            get
            {
                return _totalPrimero + this.totalHLDAsignadoG1;
            }
            set
            {
                _totalPrimero = value;
            }
        }
        public int numeroSeccionPrimero { get; set; }

        public int totalHorasPrimero
        {
            get
            {
                return (this.totalPrimero) * this.numeroSeccionPrimero;
            }
        }
        private int _totalSegundo;
        public int totalSegundo
        {
            get
            {
                return _totalSegundo + this.totalHLDAsignadoG2;
            }
            set
            {
                _totalSegundo = value;
            }
        }
        public int numeroSeccionSegundo { get; set; }
        public int totalHorasSegundo
        {
            get
            {
                return (this.totalSegundo) * this.numeroSeccionSegundo;
            }
        }
        private int _totalTercero;
        public int totalTercero
        {
            get
            {
                return _totalTercero + this.totalHLDAsignadoG3;
            }
            set
            {
                _totalTercero = value;
            }
        }
        public int numeroSeccionTercero { get; set; }
        public int totalHorasTercero
        {
            get
            {
                return (this.totalTercero) * this.numeroSeccionTercero;
            }
        }
        private int _totalCuarto;
        public int totalCuarto
        {
            get
            {
                return _totalCuarto + this.totalHLDAsignadoG4;
            }
            set
            {
                _totalCuarto = value;
            }
        }
        public int numeroSeccionCuarto { get; set; }
        public int totalHorasCuarto
        {
            get
            {
                return (this.totalCuarto) * this.numeroSeccionCuarto;
            }
        }
        public int totalQuinto { get; set; }
        public int numeroSeccionQuinto { get; set; }
        public int totalHorasQuinto
        {
            get
            {
                return (this.totalQuinto + totalHLDAsignadoG5) * this.numeroSeccionQuinto;
            }
        }

        public int totalParcial
        {

            get
            {
                return this.totalPrimero +
                        this.totalSegundo +
                        this.totalTercero +
                        this.totalCuarto +
                        this.totalQuinto;
            }
        }
        public int numeroSeccionParcial
        {
            get
            {
                return this.numeroSeccionPrimero +
                        this.numeroSeccionSegundo +
                        this.numeroSeccionTercero +
                        this.numeroSeccionCuarto +
                        this.numeroSeccionQuinto;
            }
        }
        public int totalHorasParcial
        {
            get
            {
                return this.totalHorasPrimero +
                      this.totalHorasSegundo +
                      this.totalHorasTercero +
                      this.totalHorasCuarto +
                      this.totalHorasQuinto;
            }
        }
        public int totalHLDAsignadoG1 { get; set; }
        public int totalHLDAsignadoG2 { get; set; }
        public int totalHLDAsignadoG3 { get; set; }
        public int totalHLDAsignadoG4 { get; set; }
        public int totalHLDAsignadoG5 { get; set; }
    }

    public class ReporteAnexo3RequestDTO
    {
        public int idParametroInicial { get; set; }
        public int idGrado1 { get; set; }
        public int idGrado2 { get; set; }
        public int idGrado3 { get; set; }
        public int idGrado4 { get; set; }
        public int idGrado5 { get; set; }

    }
    public class ReporteAnexo3DTO
    {
        public int orden { get; set; }
        public int idCuadroHoraServidorPublico { get; set; }
        public string codigoPlaza { get; set; }
        public string titular { get; set; }
        public string codigoModular { get; set; }
        public string jornadaLaboral { get; set; }
        public int idAreaCurricular { get; set; }
        public string escalaMagisterial { get; set; }
        public string categoriaRemunerativa { get; set; }
        public int? tiempoServicioIE { get; set; }
        public int? tiempoServicio { get; set; }
        public string descripcionEspecialidad { get; set; }
        public string observacion { get; set; }
        public string descripcionAreaCurricular { get; set; }
        public int primero { get; set; }
        public int segundo { get; set; }
        public int tercero { get; set; }
        public int cuarto { get; set; }
        public int quinto { get; set; }
        public int totalAsignado
        {
            get
            {
                return this.primero + this.segundo + this.tercero + this.cuarto + this.quinto;
            }
        }
        public int idEspecialidad { get; set; }
        public int idAfinidadAreaEspecialidad { get; set; }
        public int idHoraDistribuida { get; set; }
        public string textoUnico
        {
            get
            {

                return string.Format("Codigo Plaza: {0}<br> Titular:{1} <br>Cod. Modular:{2} <br>Espec. Titulo:{3} <br>Esc Magisterial:{4}<br> Tiempo servicio:{5}",
                                    this.codigoPlaza,
                                    this.titular,
                                    this.codigoModular,
                                    this.descripcionEspecialidad,
                                    this.escalaMagisterial,
                                    this.tiempoServicio
                                    );
            }
        }
        public string textoUnicoPdf
        {
            get
            {

                return string.Format("Codigo Plaza: {0}\n Titular:{1}\n Cod. Modular:{2} \nEspec. Titulo:{3}\nEsc Magisterial:{4}\nTiempo servicio:{5}",
                                    this.codigoPlaza,
                                    this.titular,
                                    this.codigoModular,
                                    this.descripcionEspecialidad,
                                    this.escalaMagisterial,
                                    this.tiempoServicio
                                    );
            }
        }

        public int vecesRepetido { get; set; }
        public int numeroRegistro { get; set; }
        public int horaPedagojica { get; set; }
        public bool tdVisible { get; set; }
    }
    public class ReporteAnexo4DTO
    {
        public int totalRegistro { get; set; }
        public int registro { get; set; }
        public string DESCRIPCION_CARGO { get; set; }
        public string DESCRIPCION_REGIMEN_LABORAL { get; set; }
        public string DESCRIPCION_AREA_CURRICULAR { get; set; }
        public string CODIGO_PLAZA { get; set; }
        public string DESCRIPCION_JORNADA_LABORAL { get; set; }

    }

    public class ReporteAnexo5CabeceraDTO
    {
        public int ID_CENTRO_TRABAJO { get; set; }
        public string CODIGO_CENTRO_TRABAJO { get; set; }
        public string DESCRIPCION_CARGO { get; set; }
        public int HORA_SESION_APRENDIZAJE { get; set; }
    }
    public class ReporteAnexo5DetalleDTO
    {
        public string CODIGO_CENTRO_TRABAJO { get; set; }
        public string DESCRIPCION_AREA_CURRICULAR { get; set; }
        public int HORA_DICTADO { get; set; }
    }
}
