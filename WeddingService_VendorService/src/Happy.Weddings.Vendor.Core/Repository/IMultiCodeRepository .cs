using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.MultiCode;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    /// <summary>
    /// This interface is used to declare CRUD for the MultiCode
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.IRepositoryBase{Happy.Weddings.Vendor.Core.Entity.Multicode}" />
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
        Task<Multicode> GetMultiCodeById(string code);

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
