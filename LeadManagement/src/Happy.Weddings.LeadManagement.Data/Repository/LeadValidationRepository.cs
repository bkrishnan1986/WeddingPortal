#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadValidationRepository class.
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
    /// Repository class that performs lead Validation operations.
    /// </summary>
    public class LeadValidationRepository : RepositoryBase<Leadvalidation>, ILeadValidationRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<LeadValidationResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<LeadValidationResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadValidationRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public LeadValidationRepository(
            LeadContext repositoryContext,
            IMapper mapper,
            ISortHelper<LeadValidationResponse> sortHelper,
            IDataShaper<LeadValidationResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }



        /// <summary>
        /// Gets All the lead Validation.
        /// </summary>
        /// <param name="leadValidationParameter">The lead Validation parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllLeadValidation(LeadValidationParameter leadValidationParameter)
        {
            var leadValidation = FindByCondition(x => x.Active == Convert.ToInt16(true)).ProjectTo<LeadValidationResponse>(mapper.ConfigurationProvider);
            var sortedValidation = sortHelper.ApplySort(leadValidation, leadValidationParameter.OrderBy);
            var shapedValidation = dataShaper.ShapeData(sortedValidation, leadValidationParameter.Fields);

            return await PagedList<Entity>.ToPagedList(shapedValidation, leadValidationParameter.PageNumber, leadValidationParameter.PageSize);
        }

        /// <summary>
        /// Gets the lead Validation by identifier.
        /// </summary>
        /// <param name="leadValidationId">The identifier.</param>
        /// <returns></returns>
        public async Task<Leadvalidation> GetLeadValidation(int leadValidationId)
        {
            return await FindByCondition(leadValidation => leadValidation.Id.Equals(leadValidationId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Create the lead Validation.
        /// </summary>
        /// <param name="leadvalidation">The leadvalidation.</param>
        public void CreateLeadValidation(Leadvalidation leadvalidation)
        {
            Create(leadvalidation);
        }

        /// <summary>
        /// Updates the lead Validation.
        /// </summary>
        /// <param name="leadvalidation">The leadvalidation.</param>
        public void UpdateLeadValidation(Leadvalidation leadvalidation)
        {
            Update(leadvalidation);
        }

        /// <summary>
        /// Deletes the lead Validation.
        /// </summary>
        /// <param name = "leadvalidation" > The leadvalidation.</param>
        public void DeleteLeadValidation(Leadvalidation leadvalidation)
        {
            Delete(leadvalidation);
        }
    }
}
