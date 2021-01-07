using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Profile
{
    /// <summary>
    /// Requset class/model for update user profile.
    /// </summary>
    public class UpdateUserProfileRequest : ProfileAttribute
    {
        /// <summary>
        /// Gets or sets updated by.
        /// </summary>
        public int UpdatedBy { get; set; }
    }
}

