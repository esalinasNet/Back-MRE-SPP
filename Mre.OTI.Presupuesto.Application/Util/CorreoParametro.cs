using iTextSharp.text.pdf.parser;
using Mre.OTI.Presupuesto.Domain.Setting;
using System;
using System.Collections.Generic;
using System.Text;
using static Mre.OTI.Presupuesto.Application.Util.VariablesGlobales;

namespace Mre.OTI.Presupuesto.Application.Util
{
    public class CorreoParametro
    {

        public string tipoSolicitud { get; set; }
        public string link { get; set; }
        public string codigoSolicitud { get; set; }
        public string entidadSolicitante { get; set; }
        /// <summary>
        /// asunto del correo saliente
        /// </summary>
        public string asunto { get; set; }
        public string estadoSolicitud { get; set; }
        /// <summary>
        /// contenido del correo saliente
        /// </summary>
        public string cuerpo { get; set; }
        public IEnumerable<string> listaCorreos {  get; set; }

        /// <summary>
        /// configuracion de parametros de servidor de correo
        /// </summary>
        public SmtpSettings settingMail { get; set; }
        /// <summary>
        /// CentroCosto u organismo internacional
        /// </summary>
        public int idEntidadSolicitante { get; set; }
        
        public CodigoTipoEnvioCorreo destino { get; set; }



    }

}
