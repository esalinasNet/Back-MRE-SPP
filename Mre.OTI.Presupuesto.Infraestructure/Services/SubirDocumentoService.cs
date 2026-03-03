using Mre.OTI.Presupuesto.Application.DTO.SubirDocumentoService;
//using Mre.tecnologia.util.lib.Exceptions;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Services;
using Mre.OTI.Presupuesto.Application.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Infraestructure.Services
{
    public class SubirDocumentoService : IDocumentoService
    {
        private readonly HttpClient _httpClient;

        public SubirDocumentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> SubirDocumento(SubirDocumentoDTO documento)
        {
            var uri = $"{this._httpClient.BaseAddress.AbsoluteUri}{Constantes.APIDocumento.SubirDocumento}";

            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(documento.codigoSistema.ToString()), "codigoSistema");
                formData.Add(new StringContent(documento.descripcionDocumento), "descripcionDocumento");
                formData.Add(new StringContent(documento.codigoUsuarioCreacion), "codigoUsuarioCreacion");
                formData.Add(new ByteArrayContent(documento.archivo, 0, documento.archivo.Length), "archivo", documento.nombreArchivo);

                var response = await _httpClient.PostAsync(uri, formData);
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<StatusResponse>(content);
                    var result = JsonConvert.DeserializeObject<DocumentoResponse>(data.data.ToString());

                    return result.codigoDocumento;
                }
                else
                    throw new MreException("EL SERVICIO DE DOCUMENTOS NO SE ENCUENTRA DISPONIBLE, INTENTELO MAS TARDE");

            }
        }
    }

    public class StatusResponse
    {
        public object data { get; set; }
        public List<string> messages { get; set; }
        public bool result { get; set; }
    }


    public class DocumentoResponse
    {
        public string codigoDocumento { get; set; }
    }



}
