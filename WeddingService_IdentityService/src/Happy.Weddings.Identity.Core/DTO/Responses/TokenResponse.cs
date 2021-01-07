using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Core.DTO.Responses
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }
                
    }
}
