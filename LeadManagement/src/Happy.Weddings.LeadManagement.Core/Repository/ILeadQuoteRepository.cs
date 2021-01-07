#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | ILeadQuoteRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    public interface ILeadQuoteRepository : IRepositoryBase<Leadquote>
    {
        /// <summary>
        /// Leads the quote repository.
        /// </summary>
        /// <param name="leadquotes">The leadquotes.</param>
        void CreateLeadQuote(List<Leadquote> leadquotes);

        /// <summary>
        /// Gets the lead quotes.
        /// </summary>
        /// <param name="leadQuoteParameters">The lead quote parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetLeadQuotes(LeadQuoteParameters leadQuoteParameters, int leadId = 0);

        /// <summary>
        /// Gets the lead quote by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Leadquote> GetLeadQuoteById(int id);

        /// <summary>
        /// Updates the lead quote.
        /// </summary>
        /// <param name="quote">The quote.</param>
        void UpdateLeadQuote(Leadquote quote);

        /// <summary>
        /// Deletes the lead Quote.
        /// </summary>
        /// <param name = "quote" > The quote.</param>
        void DeleteLeadQuote(Leadquote quote);    
    }
}
