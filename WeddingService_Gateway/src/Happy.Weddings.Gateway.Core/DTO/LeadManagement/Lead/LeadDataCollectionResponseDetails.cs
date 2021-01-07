using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.LeadManagement;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadDataCollectionResponseDetails : LeadDataCollectionResponse
    {
        /// <summary>
        /// Gets or sets the DataCollection.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.LeadManagement.Leaddatacollection> Leaddatacollection { get; set; }
    }
}
