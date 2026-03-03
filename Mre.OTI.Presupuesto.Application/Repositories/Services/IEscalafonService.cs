//using Mre.OTI.Presupuesto.Application.DTO.SancionAdministrativa;
using Mre.OTI.Presupuesto.Application.DTO.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Mre.OTI.Presupuesto.Application.Repositories.Services
{
    public interface IEscalafonService
    {
        // Task<IEnumerable<SancionAdministrativaDTO>> ConsultarSancionAdministrativa(int idTipoDocumento, string numeroDocumento);

        Task<ResponseEscalafonDTO> ConsultarInformeEscalafonario(int idTipoDocumento,
            string numeroDocumento,
            string numeroInformeEscalafonario,
            string sede,
            string tipoSede,
            int anio);
        Task<IEnumerable<ResponseEscalafonDTO>> ConsultarInformeEscalafonarioMultiple(List<InformeEscalafonarioMultipleRequestDTO> requests);
    }
}
