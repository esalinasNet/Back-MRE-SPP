using Mre.OTI.Presupuesto.Application.DTO.SubirDocumentoService;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Services
{
    public interface IDocumentoService
    {
        Task<string> SubirDocumento(SubirDocumentoDTO documento);

        //Task<string> SubirArchivo(SubirArchivoDTO documento);
    }
}
