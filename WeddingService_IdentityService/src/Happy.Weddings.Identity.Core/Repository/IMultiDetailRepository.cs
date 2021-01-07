#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | IMultiDetailRepository interface.
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Identity.Core.Domain;
using Happy.Weddings.Identity.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.Identity.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Identity.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Identity.Core.Repository
{
    /// <summary>
    /// This interface is used to declare CRUD for the MultiDetail
    /// </summary>
    /// <seealso cref="Happy.Weddings.Identity.Core.Repository.IRepositoryBase{Happy.Weddings.Identity.Core.Entity.Multidetail}" />
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
