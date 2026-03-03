using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Domain.Setting
{
    public class GoogleReCaptchaSettings
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }

        public string UrlGoogleVerify { get; set; }

        public float Score { get; set; }

        public bool Enabled { get; set; }
    }
}
