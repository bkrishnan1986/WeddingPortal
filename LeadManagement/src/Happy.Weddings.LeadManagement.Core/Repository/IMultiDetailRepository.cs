using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    /// <summary>
    /// This interface is used to declare CRUD for the MultiDetail
    /// </summary>
    /// <seealso cref="IRepositoryBase<Multidetail>" />
    public interface IMultiDetailRepository : IRepositoryBase<Multidetail>
    {
        /// <summary>
        /// Gets all MultiDetails.
        /// </summary>
        /// <param name="multiDetailParameters">The multiDetail parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetMultiDetails(MultiDetailParameters multiDetailParameters);

        /// <summary>
        /// Gets MultiDetails.
        /// </summary>
        /// <param name="multicodeId"></param>
        /// <returns></returns>
        Task<List<Multidetail>> GetMultiDetailsByCode(string code);

        /// <summary>
        /// Gets MultiDetails.
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
