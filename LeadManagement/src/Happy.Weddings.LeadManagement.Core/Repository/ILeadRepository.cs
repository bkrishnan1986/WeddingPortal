#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | ILeadRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    public interface ILeadRepository : IRepositoryBase<Entity.Leads>
    {
        /// <summary>
        /// Gets the lead by identifier.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        Task<Entity.Leads> GetLeadById(int leadId);

        /// <summary>
        /// Gets the lead details by identifier.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        Task<LeadsResponse> GetLeadDetailsById(string leadId);

        /// <summary>
        /// Updates the lead.
        /// </summary>
        /// <param name="leadRequest">The lead request.</param>
        void UpdateLead(Entity.Leads leadRequest);

        /// <summary>
        /// Gets the last inserted identifier.
        /// </summary>
        /// <returns></returns>
        Task<int> GetLastInsertedId();

        /// <summary>
        /// Gets leads by Vendor.
        /// </summary>
        /// <param name="leadParameters">The lead parameters.</param>
        /// <returns></returns>
        Task<List<Leads>> GetLeadsByVendor(LeadsByVendorParameters leadsByVendorParameters);
    }
}
