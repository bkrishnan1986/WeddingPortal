using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Profile
{
    /// <summary>
    /// Request class/model for create user profile.
    /// </summary>
    public class CreateUserProfileRequest : ProfileAttribute
    {
        /// <summary>
        /// Gets or sets created by.
        /// </summary>
        public int CreatedBy { get; set; }
    }
}
