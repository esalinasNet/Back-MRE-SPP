using System;

namespace Mre.OTI.Presupuesto.Application.DTO.Services
{
    public class ResponseMigracionLoginDTO
    {
        public string _data { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }

    public class ResponseMigracionLoginDataDTO
    {
        public bool success { get; set; }
        public string authorization { get; set; }
        public string token { get; set; }
        public string codRespuesta { get; set; }
        public string desRespuesta { get; set; }
    }

    public class ResponseMigracionDTO
    {
        public string _data { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }


    public class ResponseMigracionDataDTO
    {
        public DatosPersonales datosPersonales { get; set; }
        public string codRespuesta { get; set; }
        public string desRespuesta { get; set; }
    }

    public class DatosPersonales
    {
        public string apepaterno { get; set; }
        public string apematerno { get; set; }
        public string nombres { get; set; }
        public string ofimigratoria { get; set; }
        public string fecnacimiento { get; set; }
        public DateTime? fecnacimientoFormato
        {
            get
            {
                if (string.IsNullOrEmpty(fecnacimiento))
                    return null;

                var fecha = fecnacimiento.Split("/");
                var anio = Convert.ToInt32(fecha[2]);
                var mes = Convert.ToInt32(fecha[1]);
                var dia = Convert.ToInt32(fecha[0]);

                return new DateTime(anio, mes, dia);
            }
        }
        public string numpasaporte { get; set; }
        public string genero { get; set; }

        #region Campos No Usados Migraciones
        //public string painacionalidad { get; set; }
        //public string numce { get; set; }
        //public string fecinscripcion { get; set; }
        //public string fecemision { get; set; }
        //public string feccaducidad { get; set; }
        //public string fecvenresidencia { get; set; }
        //public string painacimiento { get; set; }
        //public string ubiactual { get; set; }
        //public string domactual { get; set; }
        //public string estcivil { get; set; }
        //public string calmigratoria { get; set; }
        //public List<HistorialCarneExtranjeria> historialCarneExtranjeria { get; set; }
        //public List<HistorialDocumento> historialDocumento { get; set; }
        //public List<Imagenes> imagenes { get; set; }
        #endregion
    }

    public class HistorialCarneExtranjeria
    {
        public string dependencia { get; set; }
        public string numcarne { get; set; }
        public string feccaducidad { get; set; }
        public string fecemision { get; set; }
        public string estado { get; set; }
    }

    public class HistorialDocumento
    {
        public string tipo { get; set; }
        public string documento { get; set; }
        public string numero { get; set; }
        public string estado { get; set; }
    }

    public class Imagenes
    {
        public string foto { get; set; }
    }
}
