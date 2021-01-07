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
    public interface ILeadStatusRepository : IRepositoryBase<Leadstatus>
    {
        /// <summary>
        /// Gets the lead status.
        /// </summary>
        /// <param name="leadStatusParameters">The lead status parameters.</param>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetLeadStatus(LeadStatusParameter leadStatusParameters, int leadId = 0);
    }
}
