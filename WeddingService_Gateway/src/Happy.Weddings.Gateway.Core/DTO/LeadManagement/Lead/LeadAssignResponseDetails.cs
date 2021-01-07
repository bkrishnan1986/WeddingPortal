using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.LeadManagement;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadAssignResponseDetails : LeadAssignResponse
    {
        /// <summary>
        /// Gets or sets the LeadAssign.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.LeadManagement.Leadassign> Leadassign { get; set; }
    }
}
