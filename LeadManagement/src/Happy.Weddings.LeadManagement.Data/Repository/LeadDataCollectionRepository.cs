#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadDataCollectionRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;
using Happy.Weddings.LeadManagement.Core.Helpers;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Data.Repository
{
    public class LeadDataCollectionRepository : RepositoryBase<Leaddatacollection>, ILeadDataCollectionRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<LeadDataCollectionResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<LeadDataCollectionResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadDataCollectionRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        public LeadDataCollectionRepository(
            LeadContext repositoryContext,
            IMapper mapper,
            ISortHelper<LeadDataCollectionResponse> sortHelper,
            IDataShaper<LeadDataCollectionResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Creates the lead.
        /// </summary>
        /// <param name="leaddata"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateLead(Leaddatacollection leaddata)
        {
            Create(leaddata);
        }

        /// <summary>
        /// Gets all leads.
        /// </summary>
        /// <param name="leadParameters">The lead parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllLeads(LeadParameters leadParameters)
        {
            var leadCollections = FindByCondition(x => x.Active == Convert.ToInt16(true) && x.Leads.All(x=>x.Active == Convert.ToInt16(true)))
                .ProjectTo<LeadDataCollectionResponse>(mapper.ConfigurationProvider);
            SearchByPhoneNoOrLeadId(ref leadCollections, leadParameters);
            FilterByDate(ref leadCollections, leadParameters.FromDate, leadParameters.ToDate);
            var sortedStories = sortHelper.ApplySort(leadCollections, leadParameters.OrderBy);
            var shapedStories = dataShaper.ShapeData(sortedStories, leadParameters.Fields);

            return await PagedList<Entity>.ToPagedList(shapedStories, leadParameters.PageNumber, leadParameters.PageSize);
        }

        /// <summary>
        /// Gets the lead by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Leaddatacollection> GetLeadById(int id)
        {
            return await FindByCondition(X => X.Id.Equals(id)).Include(l => l.Leads).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the lead with details.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        public async Task<Leaddatacollection> GetLeadWithDetails(string phone)
        {
            return await FindByCondition(user => user.CustomerPhone1.Equals(phone) && user.Active == Convert.ToInt16(true))
                .Include(ac => ac.Leads)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Searches the by title or description.
        /// </summary>
        /// <param name="leadCollections">The lead datas.</param>
        /// <param name="searchText">The search text.</param>
        private void SearchByPhoneNoOrLeadId(ref IQueryable<LeadDataCollectionResponse> leadCollections, LeadParameters leadParameters)
        {
            if (!leadCollections.Any() ||
                string.IsNullOrWhiteSpace(leadParameters.PhoneNumber) || string.IsNullOrWhiteSpace(leadParameters.LeadId))
                return;

            if (nameof(LeadDataCollectionResponse.CustomerPhone1).Equals(leadParameters.SearchKeyword, StringComparison.OrdinalIgnoreCase))
            {
                leadCollections = leadCollections.Where(x => x.CustomerPhone1 == leadParameters.PhoneNumber);
            }
            else if (nameof(LeadsResponse.LeadId).Equals(leadParameters.SearchKeyword, StringComparison.OrdinalIgnoreCase))
            {
                leadCollections = leadCollections.Where(x => x.Leads.Any(y => y.LeadId == leadParameters.LeadId))
                                                    .Include(x => x.Leads.Where(y => y.LeadId == leadParameters.LeadId));
            }
        }

        /// <summary>
        /// Filters the by date.
        /// </summary>
        /// <param name="leadCollections">The lead datas.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        private void FilterByDate(ref IQueryable<LeadDataCollectionResponse> leadCollections, DateTime? fromDate, DateTime? toDate)
        {
            if (!leadCollections.Any())
                return;

            if (fromDate != null)
            {
                leadCollections = leadCollections.Where(s => s.CreatedAt >= fromDate);
            }
            if (toDate != null)
            {
                leadCollections = leadCollections.Where(s => s.CreatedAt <= toDate);
            }
        }
    }
}
