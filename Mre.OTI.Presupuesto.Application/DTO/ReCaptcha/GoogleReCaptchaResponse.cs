using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ReCaptcha
{
    public class GoogleReCaptchaResponse
    {
         public bool Success { get; set; }

        public float Score { get; set; }

        public string Action { get; set; }

        public DateTime ChallengeTs { get; set; } // timestamp of the challenge load (ISO format yyyy-MM-dd'T'HH:mm:ssZZ

        public string HostName { get; set; }    // the hostname of the site where the reCAPTCHA was solved

        public string[] ErrorCodes { get; set; }


    }
}
