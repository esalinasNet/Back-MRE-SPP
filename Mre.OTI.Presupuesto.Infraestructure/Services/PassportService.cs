using Mre.OTI.Presupuesto.Application.DTO.Services.Passport;
using Mre.OTI.Presupuesto.Application.Features.Autenticacion.Command;
using Mre.OTI.Presupuesto.Application.Repositories.Services;
using Mre.OTI.Presupuesto.Application.Responses.Autentication;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
 

namespace Mre.OTI.Presupuesto.Infraestructure.Services
{
    public class PassportService : IPassportService
    {
        private readonly HttpClient _httpClient;

        public PassportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AutenticationViewModel> Autenticar(AutenticarUsuarioViewModel request)
        {
            var uri = $"{this._httpClient.BaseAddress.AbsoluteUri}{Constantes.APIPassport.validacionLogin}";
           
            try
            {
                using (var httpclient = new HttpClient())
                {
                    var json = JsonSerializer.Serialize(request);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpclient.PostAsync(uri, data);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("EL SERVICIO DE DOCUMENTOS NO SE ENCUENTRA DISPONIBLE, INTENTELO MAS TARDE");

                    var result = await response.Content.ReadAsStringAsync();
                    var responseApi = JsonSerializer.Deserialize<AutenticationViewModel>(result);

                    if (responseApi != null)
                        return responseApi;// JsonSerializer.Deserialize<IEnumerable<ObtenerUsuarioLoginResponseDTO>>(responseApi.data.ToString());
                    else
                        return null;
                }
                //return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public async Task<ProyectoResolucionGenerarDirectoResponseDTO> EnviarGuardarProyectoResolucionDirecto(ProyectoResolucionRequestViewModel proyectoResolucionRequest)
        //{
        //    var uri = $"{this._httpClient.BaseAddress.AbsoluteUri}{Constantes.APIAccionesGrabadas.guardarProyectoResolucion}";
        //    //var uri = $"{Constantes.APIAccionesGrabadas.guardarProyectoResolucion}";

        //    using (var formData = new MultipartFormDataContent())
        //    {
        //        //formData.Add(new StringContent(proyectoResolucionRequest.idAccionPersonal.ToString()), "idAccionPersonal");
        //        formData.Add(new StringContent(proyectoResolucionRequest.idTipoResolucion.ToString()), "idTipoResolucion");
        //        formData.Add(new StringContent(proyectoResolucionRequest.codigoTipoResolucion.ToString()), "codigoTipoResolucion");
        //        formData.Add(new StringContent(proyectoResolucionRequest.esProyectoIndividual.ToString()), "esProyectoIndividual");
        //        formData.Add(new StringContent(proyectoResolucionRequest.codigoSistema.ToString()), "codigoSistema");
        //        formData.Add(new StringContent(proyectoResolucionRequest.codigosTerna.codigoRegimenLaboral.ToString()), "codigosTerna.codigoRegimenLaboral");
        //        formData.Add(new StringContent(proyectoResolucionRequest.codigosTerna.codigoGrupoAccion.ToString()), "codigosTerna.codigoGrupoAccion");
        //        formData.Add(new StringContent(proyectoResolucionRequest.codigosTerna.codigoAccion.ToString()), "codigosTerna.codigoAccion");
        //        formData.Add(new StringContent(proyectoResolucionRequest.codigosTerna.codigoMotivoAccion.ToString()), "codigosTerna.codigoMotivoAccion");
        //        formData.Add(new StringContent((proyectoResolucionRequest.codigosTerna.codigoUgel == null) ? "" : proyectoResolucionRequest.codigosTerna.codigoUgel.ToString()), "codigosTerna.codigoUgel");
        //        formData.Add(new StringContent((proyectoResolucionRequest.codigosTerna.codigoDre == null) ? "" : proyectoResolucionRequest.codigosTerna.codigoDre.ToString()), "codigosTerna.codigoDre");

        //        var indexListAccionesGrabadas = 0;
        //        foreach (var data in proyectoResolucionRequest.listaIdAccionesGrabadas)
        //        {
        //            formData.Add(new StringContent(data.idAccionGrabada.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].idAccionGrabada");
        //            formData.Add(new StringContent(data.idRegimenLaboral.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].idRegimenLaboral");
        //            formData.Add(new StringContent(data.idGrupoAccion.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].idGrupoAccion");
        //            formData.Add(new StringContent(data.idAccion.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].idAccion");
        //            formData.Add(new StringContent(data.idMotivoAccion.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].idMotivoAccion");
        //            formData.Add(new StringContent(data.codigoPlaza.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].codigoPlaza");
        //            formData.Add(new StringContent(data.idDetalleAccionGrabada.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].idDetalleAccionGrabada");
        //            formData.Add(new StringContent(data.esLista.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].esLista");
        //           // formData.Add(new StringContent(data.esMandatoJudicial.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].esMandatoJudicial");
        //            formData.Add(new StringContent((data.codigoCentroTrabajo == null) ? "" : data.codigoCentroTrabajo.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].codigoCentroTrabajo");
        //            formData.Add(new StringContent((data.codigoAnexoCentroTrabajo == null) ? "" : data.codigoAnexoCentroTrabajo.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].codigoAnexoCentroTrabajo");
        //            formData.Add(new StringContent((data.codigoServidorPublico == null) ? "" : data.codigoServidorPublico.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].codigoServidorPublico");
        //            formData.Add(new StringContent((data.codigoTipoDocumentoIdentidad == null) ? "" : data.codigoTipoDocumentoIdentidad.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].codigoTipoDocumentoIdentidad");
        //            formData.Add(new StringContent((data.numeroDocumentoIdentidad == null) ? "" : data.numeroDocumentoIdentidad.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].numeroDocumentoIdentidad");
        //            formData.Add(new StringContent((data.codigoTipoDocumentoEmpresa == null) ? "" : data.codigoTipoDocumentoEmpresa.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].codigoTipoDocumentoEmpresa");
        //            formData.Add(new StringContent((data.numeroRuc == null) ? "" : data.numeroRuc.ToString()), "listaIdAccionesGrabadas[" + indexListAccionesGrabadas + "].numeroRuc");

        //            indexListAccionesGrabadas++;
        //        }

        //        var indexDetalleDocumentos = 0;
        //        foreach (var data in proyectoResolucionRequest.detalleDocumentos)
        //        {
        //            //trasformacion de FormFile to Arraybyte
        //            var formFile = data.archivoSustento;
        //            await using var memoryStream = new MemoryStream();
        //            await formFile.CopyToAsync(memoryStream);
        //            var archivoTemp = memoryStream.ToArray();
        //            //******

        //            formData.Add(new StringContent((data.codigoPlaza == null) ? "" : data.codigoPlaza.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].codigoPlaza");
        //            formData.Add(new StringContent(data.idAccionGrabada.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].idAccionGrabada");
        //          //  formData.Add(new StringContent(data.idTipoDocumentoSustento.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].idTipoDocumentoSustento");
        //         //   formData.Add(new StringContent(data.idTipoFormatoSustento.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].idTipoFormatoSustento");
        //            formData.Add(new StringContent(data.numeroDocumentoSustento.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].numeroDocumentoSustento");
        //            formData.Add(new StringContent(data.entidadEmisora.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].entidadEmisora");
        //            formData.Add(new StringContent(data.fechaEmision.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].fechaEmision");
        //            formData.Add(new StringContent(data.numeroFolios.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].numeroFolios");
        //            formData.Add(new StringContent((data.sumilla == null) ? "" : data.sumilla.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].sumilla");
        //            formData.Add(new StringContent((data.codigoDocumentoSustento == null) ? "" : data.codigoDocumentoSustento.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].codigoDocumentoSustento");
        //            formData.Add(new StringContent(data.vistoProyecto.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].vistoProyecto");
        //            formData.Add(new StringContent(data.activo.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].activo");
        //            formData.Add(new StringContent(data.fechaCreacion.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].fechaCreacion");
        //            formData.Add(new StringContent(data.usuarioCreacion.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].usuarioCreacion");
        //            formData.Add(new StringContent((data.ipCreacion == null) ? "" : data.ipCreacion.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].ipCreacion");
        //            formData.Add(new ByteArrayContent(archivoTemp, 0, archivoTemp.Length), "detalleDocumentos[" + indexDetalleDocumentos + "].archivoSustento", data.nombreArchivoSustento.ToString());
        //            formData.Add(new StringContent(data.nombreArchivoSustento.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].nombreArchivoSustento");
        //            formData.Add(new StringContent(data.codigoTipoDocumentoSustento.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].codigoTipoDocumentoSustento");
        //            formData.Add(new StringContent(data.codigoTipoFormatoSustento.ToString()), "detalleDocumentos[" + indexDetalleDocumentos + "].codigoTipoFormatoSustento");

        //            indexDetalleDocumentos++;
        //        }

        //        var indexDetalleConsiderando = 0;
        //        foreach (var data in proyectoResolucionRequest.detalleConsiderando)
        //        {
        //            formData.Add(new StringContent(data.codigoSeccion.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].codigoSeccion");
        //            formData.Add(new StringContent(data.codigoTipoSeccion.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].codigoTipoSeccion");
        //            formData.Add(new StringContent(data.orden.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].orden");
        //            formData.Add(new StringContent(data.considerando.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].considerando");
        //            formData.Add(new StringContent(data.sangria.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].sangria");
        //            formData.Add(new StringContent(data.activo.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].activo");
        //            formData.Add(new StringContent(data.fechaCreacion.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].fechaCreacion");
        //            formData.Add(new StringContent(data.usuarioCreacion.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].usuarioCreacion");
        //            formData.Add(new StringContent((data.ipCreacion == null) ? "" : data.ipCreacion.ToString()), "detalleConsiderando[" + indexDetalleConsiderando + "].ipCreacion");

        //            indexDetalleConsiderando++;
        //        }
        //        int idxAnexos = 0;
        //        foreach (var data in proyectoResolucionRequest.listaReporteAnexos)
        //        {
        //            formData.Add(new StringContent(data), "listaReporteAnexos[" + idxAnexos + "]");
        //            idxAnexos++;
        //        }
        //        int idx = 0;
        //        foreach (var data in proyectoResolucionRequest.listaValorAdicional)
        //        {
        //            formData.Add(new StringContent(data), "listaValorAdicional[" + idx + "]");
        //            idx++;
        //        }
        //        try
        //        {
        //            var response = await _httpClient.PostAsync(uri, formData);
        //            string content = await response.Content.ReadAsStringAsync();

        //            if (!response.IsSuccessStatusCode)
        //                throw new Exception("EL SERVICIO DE ACCIONES GRABADAS NO SE ENCUENTRA DISPONIBLE, INTENTELO MAS TARDE");

        //            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ProyectoResolucionGenerarDirectoResponseDTO>(content);
        //            //var result = JsonConvert.DeserializeObject<DocumentoResponse>(data.data.ToString());
        //            return result;
        //        }
        //        catch(Exception ex)
        //        {
        //            throw ex;
        //        }

        //        //var responseHttpRegistro = ApiCaller.ApiClient<StatusResponse>(HttpMethod.Post, urlProyectoAccionesGrabadas, metodoGuardarProyectoResolucion, formData);
        //        //if (!responseHttpRegistro.result) return 0;
        //        //var resultado = JsonSerializer.Deserialize<int>(responseHttpRegistro.data.ToString());
        //        //return resultado;
        //    }

        //}
        //public async Task<int> MandarAccionesGrabadasDirecto(List<AccionesGrabadasViewModel> accionesGrabadasRequest)
        //{
        //    try
        //    {
        //        using (var httpclient = new HttpClient())
        //        {
        //            var uri = $"{this._httpClient.BaseAddress.AbsoluteUri}{Constantes.APIAccionesGrabadas.enviarAccionesGrabadasDirecto}";
        //            //var uri = $"{Constantes.APIAccionesGrabadas.enviarAccionesGrabadasDirecto}";
        //            var json = Newtonsoft.Json.JsonConvert.SerializeObject(accionesGrabadasRequest);
        //            var httpContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
        //            var response = await httpclient.PostAsync(uri, httpContent);
        //            string content = await response.Content.ReadAsStringAsync();
        //            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(content);
        //            if (result == 0)
        //            {
        //                throw new Exception("EL SERVICIO DE ACCIONES GRABADAS NO SE ENCUENTRA DISPONIBLE, INTENTELO MAS TARDE");
        //            }
        //            return result;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }

        //}

    }
}
