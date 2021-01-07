using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    /// <summary>
    /// Interface For IServiceOfferedRepository
    /// </summary>
    public interface IServiceOfferRepository : IRepositoryBase<Serviceoffered>
    {
        /// <summary>
        /// Gets the services offered by service identifier.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns></returns>
        Task<List<Serviceoffered>> GetServicesOfferedByServiceId(int serviceId);
        /// <summary>
        /// Creates the services offered.
        /// </summary>
        /// <param name="serviceOffered">The service offered.</param>
        void CreateServicesOffer(Serviceoffered serviceOffered);
        /// <summary>
        /// Updates the services offered.
        /// </summary>
        /// <param name="serviceOffered">The service offered.</param>
        void UpdateServicesOffer(Serviceoffered serviceOffered);

    }
}
