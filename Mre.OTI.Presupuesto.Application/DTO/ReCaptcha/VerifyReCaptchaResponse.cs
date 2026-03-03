using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.OTI.Presupuesto.Application.DTO.ReCaptcha
{
    public class VerifyReCaptchaResponse
    {
            public bool Success { get; set; }
            public string Error { get; set; }
            public string ErrorCode { get; set; }
    }
}
