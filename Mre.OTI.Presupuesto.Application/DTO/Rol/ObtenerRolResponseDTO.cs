namespace Mre.OTI.Presupuesto.Application.DTO.Rol
{
    public class ObtenerRolResponseDTO
    {
        public int idRol { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public int codigoRol { get; set; }

        public int IdSistema { get; set; }

        public string nombreSistema { get; set; }

        public bool activo { get; set; }


    }
}
