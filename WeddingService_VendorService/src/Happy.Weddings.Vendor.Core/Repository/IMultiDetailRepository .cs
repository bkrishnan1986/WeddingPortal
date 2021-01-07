using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.Vendor.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    /// <summary>
    /// This interface is used to declare CRUD for the MultiDetail
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.IRepositoryBase{Happy.Weddings.Vendor.Core.Entity.Multidetail}" />
    public interface IMultiDetailRepository : IRepositoryBase<Multidetail>
    {
        /// <summary>
        /// Gets all story.
        /// </summary>
        /// <param name="multiDetailParameters">The multiDetail parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetMultiDetails(MultiDetailParameters multiDetailParameters);

        /// <summary>
        /// Gets all story.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<List<Multidetail>> GetMultiDetailsById(string code);

        /// <summary>
        /// Gets all story.
        /// </summary>
        /// <param name="multidetailId"></param>
        /// <returns></returns>
        Task<Multidetail> GetMultiDetailByMultiDetailId(int multidetailId);

        /// <summary>
        /// Creates the multidetail.
        /// </summary>
        /// <param name="multidetail">The multidetail.</param>
        void CreateMultiDetails(Multidetail multidetail);

        /// <summary>
        /// Updates the multidetail.
        /// </summary>
        /// <param name="multidetail">The multidetail.</param>
        void UpdateMultiDetails(Multidetail multidetail);

        /// <summary>
        /// Deletes the multidetail.
        /// </summary>
        /// <param name="multidetail">The multidetail.</param>
        void DeleteMultiDetails(Multidetail multidetail);
    }
}
