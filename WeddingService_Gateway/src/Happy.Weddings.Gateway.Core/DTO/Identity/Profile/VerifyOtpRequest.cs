using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Profile
{
    /// <summary>
    /// VerifyOtpRequest
    /// </summary>
    public class VerifyOtpRequest
    {
        public string Otp { get; set; }

        public int ProfileId { get; set; }
    }
}
