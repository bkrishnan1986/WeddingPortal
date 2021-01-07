#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | ILeadAssignRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Threading.Tasks;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    public interface ILeadAssignRepository : IRepositoryBase<Leadassign>
    {

        /// <summary>
        /// Gets the lead Assign.
        /// </summary>
        /// <param name="leadAssignParameter">The lead Assign parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllLeadAssign(LeadAssignParameter leadAssignParameter);

        /// <summary>
        /// Gets the lead Assign by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Leadassign> GetLeadAssign(int leadAssignId);

        /// <summary>
        /// Create the Lead Assign repository.
        /// </summary>
        /// <param name="assign">The leadAssign.</param>
        void CreateLeadAssign(Leadassign assign);

        /// <summary>
        /// Updates the lead Assign.
        /// </summary>
        /// <param name="assign">The Assign.</param>
        void UpdateLeadAssign(Leadassign assign);

        /// <summary>
        /// Deletes the lead Assign.
        /// </summary>
        /// <param name = "assign" > The Assign.</param>
        void DeleteLeadAssign(Leadassign assign);

        Task<List<LeadAssignDetailResponse>> GetLeadsByVendor(LeadsByVendorParameters leadsByVendorParameters);
    }
}
