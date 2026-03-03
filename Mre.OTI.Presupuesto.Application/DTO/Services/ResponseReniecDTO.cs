using System;
using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Application.DTO.Services
{
    public class ResponseReniecDTO
    {
        public List<string> messages { get; set; }
        public List<string> code { get; set; }
        public bool success { get; set; }
        public ReniecData data { get; set; }
    }

    public class ReniecData
    {
        public string numeroDni { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombres { get; set; }
        public string sexo { get; set; }
        public string sexo1
        {
            get
            {
                var result = string.Empty;
                if (!string.IsNullOrEmpty(sexo))
                    switch (Convert.ToInt32(sexo))
                    {
                        case (int)SexoReniec.Masculino:
                            result = SexoReniec.Masculino.ToString();
                            break;
                        case (int)SexoReniec.Femenino:
                            result = SexoReniec.Femenino.ToString();
                            break;
                    }

                return result;
            }
        }

        public string fechaNacimiento { get; set; }
        public DateTime? fechaNacimientoFormato
        {
            get
            {
                DateTime? fecha = null;
                if (!string.IsNullOrEmpty(fechaNacimiento) && fechaNacimiento.Length == 8)
                {
                    var anio = Convert.ToInt32(fechaNacimiento.Substring(0, 4));
                    var mes = Convert.ToInt32(fechaNacimiento.Substring(5, 6));
                    var dia = Convert.ToInt32(fechaNacimiento.Substring(7, 8));
                    fecha = new DateTime(anio, mes, dia);
                }
                return fecha;
            }
        }
        public enum SexoReniec
        {
            Masculino = 1,
            Femenino = 2
        }

        #region Campos No Usados Reniec

        //public string descripcionSexo { get; set; }
        //public string numeroDocumentoSustentatorio { get; set; }
        //public string descripcionEstadoCivil { get; set; }
        //public string apellidoCasada { get; set; }
        //public string apellidoMaternoApp { get; set; }
        //public string codigoGradoInstruccion { get; set; }
        //public string descripcionGradoInstruccion { get; set; }
        //public string estatura { get; set; }
        //public string digitoVerificacion { get; set; }
        //public string codigoUbigeoContinenteDomicilio { get; set; }
        //public string codigoUbigeoPaisDomicilio { get; set; }
        //public string codigoUbigeoDepartamentoDomicilio { get; set; }
        //public string codigoUbigeoProvinciaDomicilio { get; set; }
        //public string codigoUbigeoDistritoDomicilio { get; set; }
        //public string continenteDomicilio { get; set; }
        //public string paisDomicilio { get; set; }
        //public string departamentoDomicilio { get; set; }
        //public string provinciaDomicilio { get; set; }
        //public string distritoDomicilio { get; set; }
        //public string codigoEstadoCivil { get; set; }
        //public string codigoEstadoCivil1
        //{
        //    get
        //    {
        //        var result = string.Empty;
        //        if (!string.IsNullOrEmpty(codigoEstadoCivil))
        //            switch (Convert.ToInt32(codigoEstadoCivil))
        //            {
        //                case (int)CodigoEstadoCivilReniec.Casado:
        //                    result = CodigoEstadoCivilReniec.Casado.ToString();
        //                    break;
        //                case (int)CodigoEstadoCivilReniec.Divorciado:
        //                    result = CodigoEstadoCivilReniec.Divorciado.ToString();
        //                    break;
        //                case (int)CodigoEstadoCivilReniec.Soltero:
        //                    result = CodigoEstadoCivilReniec.Soltero.ToString();
        //                    break;
        //                case (int)CodigoEstadoCivilReniec.Viudo:
        //                    result = CodigoEstadoCivilReniec.Viudo.ToString();
        //                    break;
        //            }

        //        return result;
        //    }
        //}
        //public string codigoDocumentoSustentatorio { get; set; }
        //public string descripcionDocumentoSustentatorio { get; set; }
        //public string codigoUbigeoContinenteNacimiento { get; set; }
        //public string codigoUbigeoPaisNacimiento { get; set; }
        //public string codigoUbigeoDepartamentoNacimiento { get; set; }
        //public string codigoUbigeoProvinciaNacimiento { get; set; }
        //public string codigoUbigeoDistritoNacimiento { get; set; }
        //public string continenteNacimiento { get; set; }
        //public string paisNacimiento { get; set; }
        //public string departamentoNacimiento { get; set; }
        //public string provinciaNacimiento { get; set; }
        //public string distritoNacimiento { get; set; }
        //public string codigoTipoDocumentoPadre { get; set; }
        //public string tipoDocumentoPadre { get; set; }
        //public string numeroDocumentoPadre { get; set; }
        //public string nombrePadre { get; set; }
        //public string codigoTipoDocumentoMadre { get; set; }
        //public string tipoDocumentoMadre { get; set; }
        //public string numeroDocumentoMadre { get; set; }
        //public string nombreMadre { get; set; }
        //public string fechaInscripcion { get; set; }
        //public DateTime? fechaInscripcion1
        //{
        //    get
        //    {
        //        DateTime? fecha = null;
        //        if (!string.IsNullOrEmpty(fechaInscripcion) && fechaInscripcion.Length == 8)
        //        {
        //            var anio = Convert.ToInt32(fechaInscripcion.Substring(0, 4));
        //            var mes = Convert.ToInt32(fechaInscripcion.Substring(5, 6));
        //            var dia = Convert.ToInt32(fechaInscripcion.Substring(7, 8));
        //            fecha = new DateTime(anio, mes, dia);
        //        }
        //        return fecha;
        //    }
        //}
        //public string fechaExpedicion { get; set; }
        //public DateTime? fechaExpedicion1
        //{
        //    get
        //    {
        //        DateTime? fecha = null;
        //        if (!string.IsNullOrEmpty(fechaExpedicion) && fechaExpedicion.Length == 8)
        //        {
        //            var anio = Convert.ToInt32(fechaExpedicion.Substring(0, 4));
        //            var mes = Convert.ToInt32(fechaExpedicion.Substring(5, 6));
        //            var dia = Convert.ToInt32(fechaExpedicion.Substring(7, 8));
        //            fecha = new DateTime(anio, mes, dia);
        //        }
        //        return fecha;
        //    }
        //}
        //public string codigoConstanciaVotacion { get; set; }
        //public string descripcionConstanciaVotacion { get; set; }
        //public string fechaCaducidad { get; set; }
        //public DateTime? fechaCaducidad1
        //{
        //    get
        //    {
        //        DateTime? fecha = null;
        //        if (!string.IsNullOrEmpty(fechaCaducidad) && fechaCaducidad.Length == 8)
        //        {
        //            var anio = Convert.ToInt32(fechaCaducidad.Substring(0, 4));
        //            var mes = Convert.ToInt32(fechaCaducidad.Substring(5, 6));
        //            var dia = Convert.ToInt32(fechaCaducidad.Substring(7, 8));
        //            fecha = new DateTime(anio, mes, dia);
        //        }
        //        return fecha;
        //    }
        //}
        //public string codigoRestriccion { get; set; }
        //public string descripcionRestriccion { get; set; }
        //public string codigoGrupoRestriccion { get; set; }
        //public string descripcionGrupoRestriccion { get; set; }
        //public string codigoPrefijoDireccion { get; set; }
        //public string descripcionPrefijoDireccion { get; set; }
        //public string direccion { get; set; }
        //public string numeroDireccion { get; set; }
        //public string blockChalet { get; set; }
        //public string interior { get; set; }
        //public string urbanizacion { get; set; }
        //public string etapa { get; set; }
        //public string manzana { get; set; }
        //public string lote { get; set; }
        //public string codigoPrefijoBlockChalet { get; set; }
        //public string descripcionPrefijoBlockChalet { get; set; }
        //public string codigoPrefijoDptoPisoInterior { get; set; }
        //public string descripcionPrefijoDptoPisoInterior { get; set; }
        //public string codigoPrefijoUrbCondResid { get; set; }
        //public string descripcionPrefijoUrbCondResid { get; set; }
        //public string domicilioApp { get; set; }




        //public enum CodigoEstadoCivilReniec
        //{
        //    Soltero = 1,
        //    Casado = 2,
        //    Viudo = 3,
        //    Divorciado = 4
        //}


        #endregion
    }
}
