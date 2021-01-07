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
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using Happy.Weddings.LeadManagement.Core.Entity;
using Happy.Weddings.LeadManagement.Data.Repository;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Core.Helpers;
using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using MySql.Data.MySqlClient;
using System.Linq;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using System;
using Happy.Weddings.LeadManagement.Data.DatabaseContext;

#endregion

namespace Happy.Weddings.Lead.Data.Repository
{
    /// <summary>
    /// Repository class that performs lead quote operations.
    /// </summary>
    public class LeadStatusRepository : RepositoryBase<Leadstatus>, ILeadStatusRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<LeadStatusResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<LeadStatusResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadQuoteRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public LeadStatusRepository(
            LeadContext repositoryContext,
            IMapper mapper,
            ISortHelper<LeadStatusResponse> sortHelper,
            IDataShaper<LeadStatusResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }



        /// <summary>
        /// Gets the lead quotes.
        /// </summary>
        /// <param name="leadQuoteParameters">The lead quote parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetLeadStatus(LeadStatusParameter leadStatusParameter, int leadId = 0)
        {

                var leadStatusCollections = FindByCondition(x => x.Active == Convert.ToInt16(true) && x.LeadId.Equals(leadId)).ProjectTo<LeadStatusResponse>(mapper.ConfigurationProvider);
                var sortedStories = sortHelper.ApplySort(leadStatusCollections, leadStatusParameter.OrderBy);
                FilterByDate(ref sortedStories, leadStatusParameter.FromDate, leadStatusParameter.ToDate);
                var shapedStories = dataShaper.ShapeData(sortedStories, leadStatusParameter.Fields);
                return await PagedList<Entity>.ToPagedList(shapedStories, leadStatusParameter.PageNumber, leadStatusParameter.PageSize);
            
        }
        /// <summary>
        /// Filters the by date.
        /// </summary>
        /// <param name="leadCollections">The lead datas.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        private void FilterByDate(ref IQueryable<LeadStatusResponse> leadStatusCollections, DateTime? fromDate, DateTime? toDate)
        {
            if (!leadStatusCollections.Any())
                return;

            if (fromDate != null)
            {
                leadStatusCollections = leadStatusCollections.Where(s => s.CreatedAt >= fromDate);
            }
            if (toDate != null)
            {
                leadStatusCollections = leadStatusCollections.Where(s => s.CreatedAt <= toDate);
            }
        }

    }
}
