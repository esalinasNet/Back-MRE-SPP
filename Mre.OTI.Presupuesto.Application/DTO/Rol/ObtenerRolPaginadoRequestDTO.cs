using Mre.OTI.Presupuesto.Application.Base.DTO;

namespace Mre.OTI.Presupuesto.Application.DTO.Rol
{
    public class ObtenerRolPaginadoRequestDTO : Pagination
    {
        public string nombreSistema { get; set; }
        public int idRol { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }



    }
}
