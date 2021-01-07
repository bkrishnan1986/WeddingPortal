#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | IRepositoryWrapper class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Gets the multicodes.
        /// </summary>
        IMultiCodeRepository MultiCodes { get; }

        /// <summary>
        /// Gets the multidetails.
        /// </summary>
        IMultiDetailRepository MultiDetails { get; }

        /// <summary>
        /// Gets the lead.
        /// </summary>
        /// <value>
        /// The lead.
        /// </value>
        ILeadDataCollectionRepository LeadDataRepository { get; }

        /// <summary>
        /// Gets the lead.
        /// </summary>
        /// <value>
        /// The lead.
        /// </value>
        ILeadRepository LeadRepository { get; }

        /// <summary>
        /// Gets the lead quote repository.
        /// </summary>
        /// <value>
        /// The lead quote repository.
        /// </value>
        ILeadQuoteRepository LeadQuoteRepository { get; }

        /// <summary>
        /// Gets the lead Validation repository.
        /// </summary>
        /// <value>
        /// The lead Validation repository.
        /// </value>
        ILeadValidationRepository LeadValidationRepository { get; }

        /// <summary>
        /// Gets the lead Assign repository.
        /// </summary>
        /// <value>
        /// The lead Assign repository.
        /// </value>
        ILeadAssignRepository LeadAssignRepository { get; }


        /// <summary>
        /// Gets the lead status repository.
        /// </summary>
        /// <value>
        /// The lead status repository.
        /// </value>
        ILeadStatusRepository LeadStatusRepository { get; }

        ILeadCountRepository LeadCountRepository { get; }

        ILeadTotalAmtRepository LeadTotalAmtRepository { get; }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();
    }
}
