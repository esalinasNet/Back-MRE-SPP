namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class ObtenerUsuarioLoginResponseDTO
    {
        public int idUsuarioRol { get; set; }
        public int idRol { get; set; }
        public string nombres { get; set; }
        public string descripcionRol { get; set; }
        public string correo { get; set; }
        public string usuarioNT { get; set; }

        public int idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string descripcionCentroCostos { get; set; }

        public string claveNT { get; set; }
        public int codigoRol { get; set; }
        public string codigoSistema { get; set; }


    }

    public class ObtenerUsuarioLoginExteriorResponseDTO
    {
        public int idUsuarioRol { get; set; }
        public int idRol { get; set; }

        public string nombres { get; set; }

        public string descripcionRol { get; set; }

        public string correo { get; set; }

        public int idCentroCostos { get; set; }
        public string centroCostos { get; set; }
        public string descripcionCentroCostos { get; set; }

        public string descripcionCentroCosto { get; set; }

        public int codigoRol { get; set; }




    }
}
