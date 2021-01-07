using Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface ICategoryDetailsRepository : IRepositoryBase<Categorydetails>
    {
        /// <summary>
        /// Gets  event.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<Categorydetails> GetCategoryDetailsById(int categoryId);

        /// <summary>
        /// Gets the category details vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<CategoryResponse>> GetCategoryDetailsVendorId(string vendorId);

        /// <summary>
        /// Creates the categorydetails.
        /// </summary>
        /// <param name="categorydetails">The event.</param>
        void CreateCategoryDetails(Categorydetails categorydetails);

        /// <summary>
        /// Updates the categorydetails.
        /// </summary>
        /// <param name="categorydetails">The event.</param>

        void UpdateCategoryDetailsData(Categorydetails categorydetails);
    }
}
