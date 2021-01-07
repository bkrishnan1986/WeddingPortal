#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | IBenefitsRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Benefits;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Benefits
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IBenefitsRepository : IRepositoryBase<Benefits>
    {
        /// <summary>
        /// Gets all Benefits.
        /// </summary>
        /// <param name="benefitsParameter">The Benefit parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllBenefits(BenefitsParameter benefitsParameter);

        /// <summary>
        /// Gets the Benefits by identifier.
        /// </summary>
        /// <param name="benefitId">The Benefit identifier.</param>
        /// <returns></returns>
        Task<Benefits> GetBenefitById(int benefitId);

        /// <summary>
        /// Creates the Benefit.
        /// </summary>
        /// <param name="Benefit">The Benefit.</param>
        void CreateBenefit(Benefits Benefit);

        /// <summary>
        /// Updates the Benefit.
        /// </summary>
        /// <param name="Benefit">The Benefit.</param>
        void UpdateBenefit(Benefits Benefit);
    }
}
