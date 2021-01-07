using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Profile
{
    /// <summary>
    /// SendOtpRequest
    /// </summary>
    public class SendOtpRequest
    {
        public string MobileNumber { get; set; }

        public int ProfileId { get; set; }

        public int CreatedBy { get; set; }
    }
}
