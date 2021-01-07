using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    /// <summary>
    /// LeadQuote class.
    /// </summary>
    public class LeadQuote
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the type of the lead.
        /// </summary>
        /// <value>
        /// The type of the lead.
        /// </value>
        public int LeadType { get; set; }

        /// <summary>
        /// Gets or sets the type of the sub lead.
        /// </summary>
        /// <value>
        /// The type of the sub lead.
        /// </value>
        public int SubLeadType { get; set; }

        /// <summary>
        /// Gets or sets the quoted rate.
        /// </summary>
        /// <value>
        /// The quoted rate.
        /// </value>
        public decimal? QuotedRate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
    }

    /// <summary>
    /// CreateLeadQuoteRequest class.
    /// </summary>
    public class CreateLeadQuoteRequest
    {
        /// <summary>
        /// Gets or sets the lead quotes.
        /// </summary>
        /// <value>
        /// The lead quotes.
        /// </value>
        public List<LeadQuote> LeadQuotes { get; set; }
    }
}
