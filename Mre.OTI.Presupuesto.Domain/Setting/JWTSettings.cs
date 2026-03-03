using System.Collections.Generic;

namespace Mre.OTI.Presupuesto.Domain.Setting
{
    public class JWTSettings
    {
        public JWTSettings()
        {

        }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public double DurationInMinutes { get; set; }
    }
    public class Error
    {
        public List<string> messages { get; set; }

    }

}
