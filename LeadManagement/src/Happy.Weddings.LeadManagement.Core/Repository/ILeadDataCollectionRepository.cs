#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | ILeadDataCollectionRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    public interface ILeadDataCollectionRepository : IRepositoryBase<Leaddatacollection>
    {
        /// <summary>
        /// Gets the lead with details.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        Task<Leaddatacollection> GetLeadWithDetails(string phone);

        /// <summary>
        /// Creates the lead.
        /// </summary>
        /// <param name="story">The story.</param>
        void CreateLead(Leaddatacollection leaddata);

        /// <summary>
        /// Gets the lead by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Leaddatacollection> GetLeadById(int id);

        /// <summary>
        /// Gets all leads.
        /// </summary>
        /// <param name="leadParameters">The lead parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllLeads(LeadParameters leadParameters);
    }
}
