#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ISubscriptionPlansRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.DTO.Requests.SuggesstionList;
using Happy.Weddings.Vendor.Core.DTO.Requests.SuggestionList;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Suggestionlist
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface ISuggestionListRepository : IRepositoryBase<Suggestionlist>
    {
        /// <summary>
        /// Gets all Suggestionlist
        /// </summary>
        /// <param name="suggestionListParameter">The Suggestionlist parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllSuggestionLists(SuggestionListParameter suggestionListParameter);

        /// <summary>
        /// Gets the Suggestionlist by identifier.
        /// </summary>
        /// <param name="subscriptionId">The Suggestionlist identifier.</param>
        /// <returns></returns>
        Task<Suggestionlist> GetSuggestionListById(int subscriptionId);

        /// <summary>
        /// Creates the Suggestionlist
        /// </summary>
        /// <param name="subscriptionPlans">The Suggestionlist.</param>
        void CreateSuggestionList(Suggestionlist suggestionList);

        /// <summary>
        /// Updates the Suggestionlist
        /// </summary>
        /// <param name="suggestionList">The Suggestionlist.</param>
        void UpdateSuggestionList(Suggestionlist suggestionList);
    }
}
