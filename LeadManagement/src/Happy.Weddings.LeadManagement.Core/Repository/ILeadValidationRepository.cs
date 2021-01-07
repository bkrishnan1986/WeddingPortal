#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | ILeadValidationRepository class.
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

#endregion

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    public interface ILeadValidationRepository : IRepositoryBase<Leadvalidation>
    {
        /// <summary>
        /// Gets the lead Validation.
        /// </summary>
        /// <param name="leadValidationParameter">The lead Validation parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllLeadValidation(LeadValidationParameter leadValidationParameter);

        /// <summary>
        /// Gets the lead Validation by identifier.
        /// </summary>
        /// <param name="leadValidationId">The identifier.</param>
        /// <returns></returns>
        Task<Leadvalidation> GetLeadValidation(int leadValidationId);

        /// <summary>
        /// Leads the Validation repository.
        /// </summary>
        /// <param name="leadvalidation">The LeadValidation.</param>
        void CreateLeadValidation(Leadvalidation leadvalidation);

        /// <summary>
        /// Updates the lead Validation.
        /// </summary>
        /// <param name="leadvalidation">The Validation.</param>
        void UpdateLeadValidation(Leadvalidation leadvalidation);

        /// <summary>
        /// Deletes the lead Validation.
        /// </summary>
        /// <param name = "leadvalidation" > The Validation.</param>
        void DeleteLeadValidation(Leadvalidation leadvalidation);
    }
}
