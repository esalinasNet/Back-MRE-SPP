namespace Mre.OTI.Presupuesto.Application.Responses.Usuario
{
    public class ObtenerListadoUsuarioResponseViewModel //: IMapFrom<ObtenerListadoUsuarioResponseDTO>
    {
        public int idUsuario { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }

        /*  public void Mapping(Profile profile)
          {
              profile.CreateMap<ObtenerListadoUsuarioResponseDTO, ObtenerListadoUsuarioResponseViewModel>();
          }*/
    }
}
