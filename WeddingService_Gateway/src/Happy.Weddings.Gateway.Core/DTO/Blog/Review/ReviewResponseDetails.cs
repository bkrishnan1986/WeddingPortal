using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Review
{
    public class ReviewResponseDetails
    {
        /// <summary>
        /// Gets or sets the Review.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Blog.Review> Review { get; set; }
    }
}
