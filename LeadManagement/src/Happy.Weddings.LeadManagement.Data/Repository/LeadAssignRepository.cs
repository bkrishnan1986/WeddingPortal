#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadAssignRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.LeadManagement.Core.Entity;
using Happy.Weddings.LeadManagement.Data.Repository;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Core.Helpers;
using Happy.Weddings.LeadManagement.Data.DatabaseContext;
using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using MySql.Data.MySqlClient;
using System.Linq;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;

#endregion

namespace Happy.Weddings.LeadManagement.Data.Repository
{
    /// <summary>
    /// Repository class that performs lead Assign operations.
    /// </summary>
    public class LeadAssignRepository : RepositoryBase<Leadassign>, ILeadAssignRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<LeadAssignResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<LeadAssignResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadAssignRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public LeadAssignRepository(
            LeadContext repositoryContext,
            IMapper mapper,
            ISortHelper<LeadAssignResponse> sortHelper,
            IDataShaper<LeadAssignResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }



        /// <summary>
        /// Gets All the lead Assign.
        /// </summary>
        /// <param name="leadAssignParameter">The lead Assign parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllLeadAssign(LeadAssignParameter leadAssignParameter)
        {
            var leadAssign = FindByCondition(x => x.Active == Convert.ToInt16(true)).ProjectTo<LeadAssignResponse>(mapper.ConfigurationProvider);
            var sortedAssign = sortHelper.ApplySort(leadAssign, leadAssignParameter.OrderBy);
            var shapedAssign = dataShaper.ShapeData(sortedAssign, leadAssignParameter.Fields);

            return await PagedList<Entity>.ToPagedList(shapedAssign, leadAssignParameter.PageNumber, leadAssignParameter.PageSize);
        }

        /// <summary>
        /// Gets the lead Assign by identifier.
        /// </summary>
        /// <param name="leadAssignId">The identifier.</param>
        /// <returns></returns>
        public async Task<Leadassign> GetLeadAssign(int leadAssignId)
        {
            return await FindByCondition(leadAssign => leadAssign.Id.Equals(leadAssignId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Create the lead Assign.
        /// </summary>
        /// <param name="leadassign">The leadAssign.</param>
        public void CreateLeadAssign(Leadassign leadassign)
        {
            Create(leadassign);
        }

        /// <summary>
        /// Updates the lead Assign.
        /// </summary>
        /// <param name="leadassign">The leadAssign.</param>
        public void UpdateLeadAssign(Leadassign leadassign)
        {
            Update(leadassign);
        }

        /// <summary>
        /// Deletes the lead Assign.
        /// </summary>
        /// <param name = "leadassign" > The leadAssign.</param>
        public void DeleteLeadAssign(Leadassign leadassign)
        {
            Delete(leadassign);
        }

        /// <summary>
        /// Gets the leads by vendor.
        /// </summary>
        /// <param name="leadsByVendorParameters">The leads by vendor parameters.</param>
        /// <returns></returns>
        public async Task<List<LeadAssignDetailResponse>> GetLeadsByVendor(LeadsByVendorParameters leadsByVendorParameters)
        {
            var leaddetails = await FindByCondition(leadassign => leadassign.VendorId.Equals(leadsByVendorParameters.VendorId) && 
                          leadassign.Active == Convert.ToInt16(true))
                         .Include(x=>x.Lead)
                         .ProjectTo<LeadAssignDetailResponse>(mapper.ConfigurationProvider)
                         .ToListAsync();

            return leaddetails;

        }
    }
}
