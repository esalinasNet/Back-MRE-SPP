namespace Mre.OTI.Presupuesto.Application.DTO.Rol
{
    public class ObtenerRolPaginadoResponseDTO
    {
        public string nombreSistema { get; set; }

        public int idRol { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }


        public bool activo { get; set; }

        public int registro { get; set; }

        public int totalRegistro { get; set; }

        //public DateTime FechaCreacion  { get; set; } 
        //public string UsuarioCreacion  { get; set; } 
        //public string ipCreacion  { get; set; } 
        //public int FechaModificacion  { get; set; } 
        //public int UsuarioModificacion  { get; set; } 
        // public int  ipModificacion  { get; set; } 


    }
}
