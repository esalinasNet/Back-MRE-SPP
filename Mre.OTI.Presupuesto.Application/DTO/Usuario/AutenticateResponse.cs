using System.Text.Json.Serialization;

namespace Mre.OTI.Presupuesto.Application.DTO.Usuario
{
    public class AutenticateResponse
    {

        public int id { get; set; }

        public string userName { get; set; }
        public string email { get; set; }

        public bool isVerified { get; set; }
        public string JWToken { get; set; }

        [JsonIgnore]
        public string refreshToken { get; set; }

    }
}
