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
using Happy.Weddings.LeadManagement.Data.DatabaseContext;
using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using MySql.Data.MySqlClient;
using System.Linq;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using System;

#endregion

namespace Happy.Weddings.Identity.Data.Repository
{
    /// <summary>
    /// Repository class that performs lead quote operations.
    /// </summary>
    public class LeadQuoteRepository : RepositoryBase<Leadquote>, ILeadQuoteRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<LeadQuoteResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<LeadQuoteResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadQuoteRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public LeadQuoteRepository(
            LeadContext repositoryContext,
            IMapper mapper,
            ISortHelper<LeadQuoteResponse> sortHelper,
            IDataShaper<LeadQuoteResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Leads the quote repository.
        /// </summary>
        /// <param name="leadquotes">The leadquotes.</param>
        public void CreateLeadQuote(List<Leadquote> leadquotes)
        {
            CreateRange(leadquotes);
        }

        /// <summary>
        /// Gets the lead quotes.
        /// </summary>
        /// <param name="leadQuoteParameters">The lead quote parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetLeadQuotes(LeadQuoteParameters leadQuoteParameters, int leadId = 0)
        {
            if(leadId > 0)
            {
                var leadCollections = FindByCondition(x => x.Active == Convert.ToInt16(true) && x.LeadId.Equals(leadId)).ProjectTo<LeadQuoteResponse>(mapper.ConfigurationProvider);
                var sortedStories = sortHelper.ApplySort(leadCollections, leadQuoteParameters.OrderBy);
                var shapedStories = dataShaper.ShapeData(sortedStories, leadQuoteParameters.Fields);

                return await PagedList<Entity>.ToPagedList(shapedStories, leadQuoteParameters.PageNumber, leadQuoteParameters.PageSize);
            }
            else
            {
                var leadCollections = FindByCondition(x => x.Active == Convert.ToInt16(true)).ProjectTo<LeadQuoteResponse>(mapper.ConfigurationProvider);
                var sortedStories = sortHelper.ApplySort(leadCollections, leadQuoteParameters.OrderBy);
                var shapedStories = dataShaper.ShapeData(sortedStories, leadQuoteParameters.Fields);

                return await PagedList<Entity>.ToPagedList(shapedStories, leadQuoteParameters.PageNumber, leadQuoteParameters.PageSize);
            }
        }

        /// <summary>
        /// Gets the lead quote by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Leadquote> GetLeadQuoteById(int id)
        {
            return await FindByCondition(leadQuote => leadQuote.Id.Equals(id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updates the lead quote.
        /// </summary>
        /// <param name="quote">The quote.</param>
        public void UpdateLeadQuote(Leadquote quote)
        {
            Update(quote);
        }

        /// <summary>
        /// Deletes the lead quote.
        /// </summary>
        /// <param name = "quote" > The lead quote.</param>
        public void DeleteLeadQuote(Leadquote quote)
        {
            Delete(quote);
        }
    }
}
