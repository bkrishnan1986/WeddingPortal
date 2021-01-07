#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadQuoteRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using System.Linq;
using System;
using Happy.Weddings.LeadManagement.Data.DatabaseContext;

#endregion

namespace Happy.Weddings.LeadManagement.Data.Repository
{
    /// <summary>
    /// Repository class that performs lead quote operations.
    /// </summary>
    public class LeadTotalAmountRepository : RepositoryBase<Core.Entity.Leadassign>, ILeadTotalAmtRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;



        /// <summary>
        /// Initializes a new instance of the <see cref="LeadQuoteRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public LeadTotalAmountRepository(
            LeadContext repositoryContext,
            IMapper mapper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
        }



        /// <summary>
        /// Gets the lead total amount.
        /// </summary>
        /// <param name="leadCountParameter">The lead count parameter.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        public async Task<List<Core.Entity.Leadassign>> GetLeadTotalAmount(LeadCountTotAmtParameter leadCountParameter, string vendorId)
        {
            var leadCount = new List<Core.Entity.Leadassign>();
            if (leadCountParameter.IsForCPCLeadAssigned == true)
            {
                leadCount = FindByCondition(leadassign => leadassign.VendorId.Equals(vendorId) && leadassign.Active == Convert.ToInt16(true))
                           .Include(bo => bo.Lead)
                           .Where(o => o.Lead.LeadModeNavigation.Value == "CPL").ToList();
            }
            if (leadCountParameter.IsForCommisionLeadAssigned == true)
            {
                leadCount = FindByCondition(leadassign => leadassign.VendorId.Equals(vendorId) && leadassign.Active == Convert.ToInt16(true))
                            .Include(bo => bo.Lead)
                            .Where(o => o.Lead.LeadModeNavigation.Value == "Commision").ToList();
            }
            return leadCount;
        }
    }
}
