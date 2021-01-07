using System;

namespace Happy.Weddings.Gateway.Core.DTO.Identity
{
    public class ProfileIdDetails
    {
        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        /// <value>
        /// The profile identifier.
        /// </value>
        public int ProfileId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileIdDetails"/> class.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        public ProfileIdDetails(int profileId)
        {
            ProfileId = profileId;
        }
    }
}
