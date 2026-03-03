using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using Mre.OTI.Presupuesto.Domain.Setting;
using static Mre.OTI.Presupuesto.Application.Util.Constantes;
using Microsoft.AspNetCore.Http;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Passport.Util.Encriptador;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Threading.Tasks;
using Mre.OTI.Presupuesto.Application.DTO.ReCaptcha;
using Newtonsoft.Json;
using Mre.OTI.Presupuesto.Domain.Entities;
using Mre.OTI.Presupuesto.Application.Repositories;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using Org.BouncyCastle.Asn1.Ocsp;
//using Mre.OTI.Presupuesto.Application.DTO.Respuesta;
using Org.BouncyCastle.Security.Certificates;
using Mre.OTI.Passport.Util.Encriptador;

namespace Mre.OTI.Presupuesto.Application.Util
{
    public class Recursos
    {
        public static Stream GetFile_Stream(string nameFile)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().First(s => s.EndsWith(nameFile, StringComparison.CurrentCultureIgnoreCase));
            string[] demo = assembly.GetManifestResourceNames();
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }

        public static byte[] GetFile_Array(string nameFile)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().First(s => s.EndsWith(nameFile, StringComparison.CurrentCultureIgnoreCase));

            using (Stream resFilestream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resFilestream == null) return null;
                byte[] bytes = new byte[resFilestream.Length];
                resFilestream.Read(bytes, 0, bytes.Length);
                return bytes;
            }

        }
        public static int calcularDiasTotal(int anio, int mes, int dia)
        {
            var totalDiasAnio = 365 * anio;
            var totalDiasMes = 30 * mes;
            return totalDiasAnio + totalDiasMes + dia;

        }

        public static bool SendMail(CorreoParametro objCorreoParam)
        {

            if (objCorreoParam.settingMail.Enabled)
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(EncryptionPassportHandler.Decrypt(objCorreoParam.settingMail.OutgoingMail, Constantes.SISTEMA.KEY_ENCRYPT));

                string body = objCorreoParam.cuerpo;
                body = body.Replace("{tipoSolicitud}", objCorreoParam.tipoSolicitud);
                body = body.Replace("{entidadSolicitante}", objCorreoParam.entidadSolicitante);
                body = body.Replace("{codigoSolicitud}", objCorreoParam.codigoSolicitud);
                body = body.Replace("{link}", objCorreoParam.link);


                var ctasMail = objCorreoParam.listaCorreos.Where(x => IsValidEmail(x));
                
          

                if (!ctasMail.Any())
                {
                    //throw new UarmException("NO EXISTEN CORREOS DESTINATARIO.");
                    return false;
                }
                else
                {

                    ctasMail.ToList().ForEach(x =>
                    {
                      mailMessage.To.Add(x);
                    });

                    //mailMessage.To.Add("dbalvis@teon.pe");
                    //mailMessage.To.Add("aavila@teon.pe");
                    

                    if (objCorreoParam.destino == VariablesGlobales.CodigoTipoEnvioCorreo.PARA_LIMA)
                    {
                        if (string.IsNullOrEmpty(objCorreoParam.estadoSolicitud))
                            mailMessage.Subject = $"<<UARM>> GESTOR DE SOLICITUDES: {objCorreoParam.asunto} - {objCorreoParam.codigoSolicitud}";
                        else
                            mailMessage.Subject = $"<<UARM>> GESTOR DE SOLICITUDES: {objCorreoParam.asunto} - {objCorreoParam.codigoSolicitud} - {objCorreoParam.estadoSolicitud} ";
                    }
                    else
                    {
                        mailMessage.Subject = $"<<UARM>> GESTOR DE SOLICITUDES: {objCorreoParam.asunto} - {objCorreoParam.codigoSolicitud} - {objCorreoParam.estadoSolicitud} ";
                        body = body.Replace("{estado}", objCorreoParam.estadoSolicitud);
                    }

                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;

                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.Host = EncryptionPassportHandler.Decrypt(objCorreoParam.settingMail.Host, Constantes.SISTEMA.KEY_ENCRYPT);
                        smtpClient.Port = objCorreoParam.settingMail.Port;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(EncryptionPassportHandler.Decrypt(objCorreoParam.settingMail.Username, Constantes.SISTEMA.KEY_ENCRYPT), EncryptionPassportHandler.Decrypt(objCorreoParam.settingMail.Password, Constantes.SISTEMA.KEY_ENCRYPT));
                        smtpClient.EnableSsl = true;



                        try
                        {
                            smtpClient.Send(mailMessage);

                        return true;
                        }
                        catch (Exception ex)
                        {
                         return false;
                        }
                   
                }
            }
            else
            {
                return true;
            }
        }
        //public static string creaCarpetaDocumentoCargaPersonaEval90()
        //{
        //    return $"{Constantes.CodigoCarpeta.CARGAS_EVAL}/{Constantes.CodigoCarpetaCargaEval.EVAL90}";
        //}
        //public static string creaCarpetaDocumentoCargaPersonaEval180()
        //{
        //    return $"{Constantes.CodigoCarpeta.CARGAS_EVAL}/{Constantes.CodigoCarpetaCargaEval.EVAL180}";
        //}
        //public static string creaCarpetaDocumentoCargaPersonaAutoeval()
        //{
        //    return $"{Constantes.CodigoCarpeta.CARGAS_EVAL}/{Constantes.CodigoCarpetaCargaEval.AUTOEVALUACION}";
        //}
        public static string addDocumentoPdf(List<string> documentoFisico, DocumentoSettings _DocumentoSettings, IFormFile documentoPdf, string carpeta, string msgException, string destino = "UKNOW")
        {
            string documentoGenerado = "";
            if (documentoPdf != null)
            {
                string extension = Path.GetExtension(documentoPdf.FileName);
                if (extension != ".pdf") throw new MreException(msgException);
                var pathUser = string.Format(@"{0}\{1}", DateTime.Now.Year, carpeta);
                var pathFisica = string.Format(@"{0}\{1}\{2}", _DocumentoSettings.fileServerPath, destino, pathUser);

                string path = pathFisica;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Guid key = Guid.NewGuid();
                IFormFile postedFile = documentoPdf;
                string fileName = key.ToString() + Path.GetExtension(documentoPdf.FileName);

                documentoGenerado = string.Format(@"{0}\{1}", pathUser, fileName);
                documentoFisico.Add(Path.Combine(path, fileName));
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
            }
            return $"{destino}\\{documentoGenerado}";
        }
        public static string moveDocumentoPdf(List<string> documentoFisico, DocumentoSettings _DocumentoSettings, string documento, string nombreCarpeta)
        {
            string documentoGenerado = "";
            if (documento != null)
            {
                var pathFinal = string.Format(@"{0}/{1}", _DocumentoSettings.fileServerPath, nombreCarpeta);
                var docOriginalRuta = string.Format(@"{0}/{1}", _DocumentoSettings.fileServerPath, documento);
                FileInfo documentoOriginal = new FileInfo(docOriginalRuta) ;

                string path = pathFinal;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
                documentoGenerado = string.Format("{0}/{1}", nombreCarpeta, documentoOriginal.Name);
                documentoFisico.Add(Path.Combine(path, documentoOriginal.Name));
               
                var documentoCopiado = string.Format(@"{0}/{1}", path, documentoOriginal.Name);
                documentoOriginal.CopyTo(documentoCopiado);
            }
            return documentoGenerado;
        }
        public static string addDocumentoExcel(List<string> documentoFisico, DocumentoSettings _DocumentoSettings, IFormFile documentoPdf, string carpeta,string msgException,string nuevoNombreArchivo = null)
        {
            string documentoGenerado = "";
            if (documentoPdf != null)
            {
                string extension = Path.GetExtension(documentoPdf.FileName);
                if (extension != ".xls" && extension!=".xlsx") throw new MreException(msgException);
                var pathFisica = string.Format(@"{0}/{1}", _DocumentoSettings.fileServerPath, carpeta);

                string path = pathFisica;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Guid key = Guid.NewGuid();
                IFormFile postedFile = documentoPdf;
                string fileName = key.ToString() + Path.GetExtension(documentoPdf.FileName);
                if (nuevoNombreArchivo != null)
                {
                    fileName= nuevoNombreArchivo + Path.GetExtension(documentoPdf.FileName);
                }
                
                documentoFisico.Add(Path.Combine(path, fileName));

                documentoGenerado = string.Format("{0}/{1}", carpeta, fileName);

                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
            }
            return documentoGenerado;
        }
        public static string codigoNumConCeros(int codigo,int largoNum=6)
        {
            var cantidadCeros = largoNum - ((int)Math.Log10(codigo) + 1);
            var numero = "";
            for (var i = 1; i <= cantidadCeros; i++)
            {
                numero += "0";
            }
            return numero + codigo;
        }
        public static bool IsValidEmail(string strMailAddress)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
        public static string deleteArchives(List<string> archivos)
        {
            string resultado = "";
            if (archivos != null && archivos.Count() > 0)
            {
                for (var i = 0; i < archivos.Count(); i++)
                {
                    string rutaArchivo = archivos[i];
                    if (File.Exists(rutaArchivo))
                    {
                        File.Delete(rutaArchivo);
                        resultado = rutaArchivo;
                    }
                }
            }

            return resultado;
        }
        public static string addFoto(List<string> documentoFisico, DocumentoSettings _DocumentoSettings,IFormFile img, string carpeta,string excepcion)
        {
            string documentoGenerado = "";
            if (img != null)
            {
                string extension = Path.GetExtension(img.FileName);
                if (extension != ".jpg" && extension != ".png" && extension != ".jpeg") throw new MreException(excepcion);
                var pathUser = string.Format(@"{0}\{1}", DateTime.Now.Year, carpeta);
                var pathFinal = string.Format(@"{0}\{1}\{2}", _DocumentoSettings.fileServerPath, DateTime.Now.Year, carpeta);

                string path = pathFinal;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Guid key = Guid.NewGuid();
                IFormFile postedFile = img;
                string fileName = key.ToString() + Path.GetExtension(img.FileName);

                documentoGenerado = string.Format(@"{0}\{1}", pathUser, fileName);
                documentoFisico.Add(Path.Combine(path, fileName));
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
            }
            return documentoGenerado;
        }
        //public static bool validacionSumaPorcentajesFormatos(int codigoTipoValor, IEnumerable<AgregarEvaluacionFormatoDTO> colleccionObjetos)
        //{
        //    var resultado = true;
        //    if (codigoTipoValor == (int)VariablesGlobales.TablaTipoPeso.PESO_PROCENTAJE)
        //    {
        //        decimal pesoTotal = 0;
        //        foreach (var objeto in colleccionObjetos)
        //        {
        //            pesoTotal += objeto.peso;
        //        }
        //        if (pesoTotal < 100 || pesoTotal > 100) resultado = false;
        //    }
        //    return resultado;
        //}
        //public static bool validacionSumaPorcentajesEscLikert(int codigoTipoValor, IEnumerable<AgregarEscalaLikertResponseDTO> colleccionObjetos)
        //{
        //    var resultado = true;
        //    if (codigoTipoValor == (int)VariablesGlobales.TablaTipoPeso.PESO_PROCENTAJE)
        //    {
        //        decimal pesoTotal = 0;
        //        foreach (var objeto in colleccionObjetos)
        //        {
        //            pesoTotal += objeto.valor;
        //        }
        //        if (pesoTotal < 100 || pesoTotal > 100) resultado = false;
        //    }
        //    return resultado;
        //}

        //public static bool ValidacionPorcentajeTotal(List<AgregarEscalaCalificacionResponseDTO> rangos)
        //{
        //    decimal valorMayor = 0;

        //    foreach (var rangoValidar in rangos)
        //    {
        //        if (rangoValidar.valorFinal > valorMayor) {
        //            valorMayor = rangoValidar.valorFinal;
        //        }

        //    }
        //    if (valorMayor>100)
        //        return false;
        //    else
        //        return true;
            
        //}
        //public static bool ValidacionPreguntasAbiertas(List<ObtenerRespuestaAbiertaResponseDTO> respuestas)
        //{
        //    var resultado = true;
        //    var pregAbiertaCompleta = 0;
        //    foreach (var item in respuestas)
        //    {
        //        if (!string.IsNullOrEmpty(item.descripcion))
        //        {
        //            pregAbiertaCompleta++;
        //        }
        //    }
        //    if (pregAbiertaCompleta > 0) resultado = false;
        //    return resultado;
        //}
        //public static bool ValidacionTraslapeValores(List<AgregarEscalaCalificacionResponseDTO> rangos)
        //{
        //    foreach (var rangoValidar in rangos)
        //    {
        //        foreach (var rangoSeleccion in rangos)
        //        {
        //            if (rangoValidar!=rangoSeleccion)
        //            {
        //               /* if (rangoValidar.valorInicial >= rangoSeleccion.valorInicial &&
        //                    rangoValidar.valorFinal <= rangoSeleccion.valorFinal) return false;
        //                if (rangoValidar.valorInicial < rangoSeleccion.valorInicial && rangoValidar.valorFinal < rangoSeleccion.valorFinal) return false;
        //                if (rangoValidar.valorInicial > rangoSeleccion.valorInicial && rangoValidar.valorFinal > rangoSeleccion.valorInicial) return false;
        //                if (rangoValidar.valorInicial < rangoSeleccion.valorInicial &&
        //                    rangoValidar.valorFinal > rangoSeleccion.valorFinal) return false;
        //               */
        //            }

        //        }
            
        //    }

        //    return true;
        //}
        //public static async Task<bool> TieneAmbosValoresEscalaCalificacion(ICatalogoItemRepository _ICatalogoItemRepository, IEnumerable<AgregarEscalaCalificacionResponseDTO> colleccionObjetos)
        //{
        //    var resultado = false;
        //    var tienePorcentaje = false;
        //    var tienePeso = false;

        //    foreach (var objeto in colleccionObjetos)
        //    {
        //        var infoCatalogoItem = await _ICatalogoItemRepository.ObtenerCatalogoItemsActivosXIdCatalogoItem(objeto.idTipoValor);
        //        if (infoCatalogoItem.codigoCatalogoItem==(int)VariablesGlobales.TablaTipoPeso.PESO_PROCENTAJE)
        //        {
        //            tienePorcentaje = true;
        //        }
        //        else if(infoCatalogoItem.codigoCatalogoItem == (int)VariablesGlobales.TablaTipoPeso.VALOR)
        //        {
        //            tienePeso = true;
        //        }
        //    }
        //    if (tienePorcentaje && tienePeso) resultado = true;
        //    return resultado;
        //}
        //public static async Task<bool> TieneAmbosValoresEscalaLikert(ICatalogoItemRepository _ICatalogoItemRepository, IEnumerable<AgregarEscalaLikertResponseDTO> colleccionObjetos)
        //{
        //    var resultado = false;
        //    var tienePorcentaje = false;
        //    var tienePeso = false;

        //    foreach (var objeto in colleccionObjetos)
        //    {
        //        var infoCatalogoItem = await _ICatalogoItemRepository.ObtenerCatalogoItemsActivosXIdCatalogoItem(objeto.idTipoValor);
        //        if (infoCatalogoItem.codigoCatalogoItem == (int)VariablesGlobales.TablaTipoPeso.PESO_PROCENTAJE)
        //        {
        //            tienePorcentaje = true;
        //        }
        //        else if (infoCatalogoItem.codigoCatalogoItem == (int)VariablesGlobales.TablaTipoPeso.VALOR)
        //        {
        //            tienePeso = true;
        //        }
        //    }
        //    if (tienePorcentaje && tienePeso) resultado = true;
        //    return resultado;
        //}
        //public static async Task<bool> TieneAmbosValoresFormatos(ICatalogoItemRepository _ICatalogoItemRepository, IEnumerable<AgregarEvaluacionFormatoDTO> colleccionObjetos)
        //{
        //    var resultado = false;
        //    var tienePorcentaje = false;
        //    var tienePeso = false;

        //    foreach (var objeto in colleccionObjetos)
        //    {
        //        var infoCatalogoItem = await _ICatalogoItemRepository.ObtenerCatalogoItemsActivosXIdCatalogoItem(objeto.idTipoPeso);
        //        if (infoCatalogoItem.codigoCatalogoItem == (int)VariablesGlobales.TablaTipoPeso.PESO_PROCENTAJE)
        //        {
        //            tienePorcentaje = true;
        //        }
        //        else if (infoCatalogoItem.codigoCatalogoItem == (int)VariablesGlobales.TablaTipoPeso.VALOR)
        //        {
        //            tienePeso = true;
        //        }
        //    }
        //    if (tienePorcentaje && tienePeso) resultado = true;
        //    return resultado;
        //}
        //public static bool TieneFormatosIguales(IEnumerable<AgregarEvaluacionFormatoDTO> colleccionObjetos)
        //{
        //    var resultado = false;
        //    var gruposFormato = colleccionObjetos.GroupBy(objeto => objeto.idFormato);
        //    var objetosConMismoFormato= gruposFormato.Where(grupo => grupo.Count() > 1).SelectMany(grupo => grupo);

        //    if (objetosConMismoFormato!=null && objetosConMismoFormato.Any()) resultado = true;
        //    return resultado;
        //}
        public static async Task<VerifyReCaptchaResponse> VerifyTokenReCaptcha(string tokenRecaptcha, GoogleReCaptchaSettings configReCaptcha)
        {

            var dictionary = new Dictionary<string, string>
                    {
                        { "secret",configReCaptcha.SecretKey },
                        { "response", tokenRecaptcha }
                    };
            var postContent = new FormUrlEncodedContent(dictionary);
            HttpResponseMessage recaptchaResponse = null;
            string stringContent = "";
            // Call recaptcha api and validate the token
            using (var http = new HttpClient())
            {
                recaptchaResponse = await http.PostAsync(configReCaptcha.UrlGoogleVerify, postContent);
                stringContent = await recaptchaResponse.Content.ReadAsStringAsync();
            }
            if (!recaptchaResponse.IsSuccessStatusCode)
            {
                return new VerifyReCaptchaResponse { Success = false, Error = "Unable to verify recaptcha token", ErrorCode = "S03" };
            }
            if (string.IsNullOrEmpty(stringContent))
            {
                return new VerifyReCaptchaResponse { Success = false, Error = "Invalid reCAPTCHA verification response", ErrorCode = "S04" };
            }
            var googleReCaptchaResponse = JsonConvert.DeserializeObject<GoogleReCaptchaResponse>(stringContent);
            if (!googleReCaptchaResponse.Success)
            {
                var errors = string.Join(",", googleReCaptchaResponse.ErrorCodes);
                return new VerifyReCaptchaResponse { Success = false, Error = errors, ErrorCode = "S05" };
            }
            if (!(googleReCaptchaResponse.Action.Equals(SISTEMA.VAR_ACTION_RECAPTCHA_CI, StringComparison.OrdinalIgnoreCase) ||
                    googleReCaptchaResponse.Action.Equals(SISTEMA.VAR_ACTION_RECAPTCHA_EXT, StringComparison.OrdinalIgnoreCase) ||
                    googleReCaptchaResponse.Action.Equals(SISTEMA.VAR_ACTION_RECAPTCHA_PRI, StringComparison.OrdinalIgnoreCase)
                  ))
            {
                // This is important just to verify that the exact action has been performed from the UI
                return new VerifyReCaptchaResponse { Success = false, Error = "Invalid action RECAPTCHA", ErrorCode = "S06" };
            }
            // Captcha was success , let's check the score, in our case, for example, anything less than 0.5 is considered as a bot user which we would not allow ...
            // the passing score might be higher or lower according to the sensitivity of your action
            if (googleReCaptchaResponse.Score < configReCaptcha.Score)
            {
                return new VerifyReCaptchaResponse { Success = false, Error = "VERIFICACIÓN RECAPCHA: ES UN POTENCIAL ROBOT. SOLICITUD DE CONSULTA RECHAZADO.", ErrorCode = "S07" };
            }
            //TODO: Continue with doing the actual signup process, since now we know the request was done by potentially really human
            return new VerifyReCaptchaResponse { Success = true };
        }

        public static string CifrarBase64(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }


        public static string DecifrarBase64(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        
    }
}
