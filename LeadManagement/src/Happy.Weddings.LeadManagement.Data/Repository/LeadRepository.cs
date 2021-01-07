#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.LeadManagement.Data.DatabaseContext;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.Entity;
using Happy.Weddings.LeadManagement.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MySql.Data.MySqlClient;

#endregion

namespace Happy.Weddings.LeadManagement.Data.Repository
{
    public class LeadRepository : RepositoryBase<Leads>, ILeadRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapperr">The mapperr.</param>
        public LeadRepository(
            LeadContext repositoryContext,
            IMapper mapper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the lead by identifier.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public async Task<LeadsResponse> GetLeadDetailsById(string leadId)
        {
            return await FindByCondition(lead => lead.LeadId.Equals(leadId))
                .Include(lv=>lv.Leadvalidation)
                .Include(la=>la.Leadassign)
                .ProjectTo<LeadsResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updates the lead.
        /// </summary>
        /// <param name="leadRequest">The lead request.</param>
        public void UpdateLead(Leads leadRequest)
        {
            Update(leadRequest);
        }

        /// <summary>
        /// Gets the lead by Vendor.
        /// </summary>
        /// <param name="leadsByVendorParameters">The lead By Vendor Parameters.</param>
        /// <returns></returns>
        public async Task<List<Leads>> GetLeadsByVendor(LeadsByVendorParameters leadsByVendorParameters)
        {
            var getLeadsParams = new object[] {
                new MySqlParameter("@p_VendorId", leadsByVendorParameters.VendorId),
                new MySqlParameter("@p_IsForAssignedLead", leadsByVendorParameters.IsForAssignedLead),
                new MySqlParameter("@p_IsForQuotedLead", leadsByVendorParameters.IsForQuotedLead)
            };

            return await FindAll("CALL SpSelectActiveLeadsByVendor(@p_VendorId, @p_IsForAssignedLead, @p_IsForQuotedLead)", getLeadsParams).ToListAsync();
        }

        /// <summary>
        /// Gets the lead by identifier.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public async Task<Leads> GetLeadById(int leadId)
        {
            return await FindByCondition(lead => lead.Id.Equals(leadId))
               .Include(lv => lv.Leadvalidation)
               .Include(la => la.Leadassign)
               .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the last inserted identifier.
        /// </summary>
        /// <returns></returns>
        public Task<int> GetLastInsertedId()
        {
            var id = RepositoryContext.Leads.OrderByDescending(x => x.Id)?.FirstOrDefault()?.Id;
            int id2 = (int)(id == null ? default(int) : id);
            return Task.FromResult(id2);
        }
    }
}
