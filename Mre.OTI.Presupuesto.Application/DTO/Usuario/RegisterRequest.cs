namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class RegisterRequest
    {

        public int idUsuarioRol { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string ipAcceso { get; set; }

        public string descripcionRol { get; set; }
        public string descripcionCentroCosto { get; set; }
        public string idRol { get; set; }
        public string idSistema { get; set; }
        public string userName { get; set; }
        //public string password { get; set; }

        //public string confirmPassword { get; set; }

    }
}
