using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiCode;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Threading.Tasks;

namespace Happy.Weddings.LeadManagement.Core.Repository
{
    /// <summary>
    /// This interface is used to declare CRUD for the MultiCode
    /// </summary>
    /// <seealso cref="IRepositoryBase<Multicode>" />
    public interface IMultiCodeRepository : IRepositoryBase<Multicode>
    {
        /// <summary>
        /// Gets all multicode.
        /// </summary>
        /// <param name="multiCodeParameters">The multicode parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllMultiCodes(MultiCodeParameters multiCodeParameters);

        /// <summary>
        /// Gets all multicode.
        /// </summary>
        /// <param name="multicodeId"></param>
        /// <returns></returns>
        Task<Multicode> GetMultiCode(string code);

        /// <summary>
        /// Creates the multiCode.
        /// </summary>
        /// <param name="multiCode">The multiCode.</param>
        void CreateMultiCode(Multicode multiCode);

        /// <summary>
        /// Updates the multiCode.
        /// </summary>
        /// <param name="multiCode">The multiCode.</param>
        void UpdateMultiCode(Multicode multiCode);

        /// <summary>
        /// Deletes the multiCode.
        /// </summary>
        /// <param name="multiCode">The multiCode.</param>
        void DeleteMultiCode(Multicode multiCode);
    }
}
