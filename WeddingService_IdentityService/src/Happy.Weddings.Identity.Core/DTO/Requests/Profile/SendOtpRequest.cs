using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Core.DTO.Requests.Profile
{
    public class SendOtpRequest
    {
        public string MobileNumber { get; set; }

        public int CreatedBy { get; set; }
    }
}
