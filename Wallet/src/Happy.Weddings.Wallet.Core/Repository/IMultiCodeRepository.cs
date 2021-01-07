#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | IMultiCodeRepository interface.
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.MultiCode;
using Happy.Weddings.Wallet.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Core.Repository
{
    /// <summary>
    /// This interface is used to declare CRUD for the MultiCode
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.IRepositoryBase{Happy.Weddings.Wallet.Core.Entity.Multicode}" />
    public interface IMultiCodeRepository : IRepositoryBase<Multicode>
    {
        /// <summary>
        /// Gets all multicode.
        /// </summary>
        /// <param name="multiCodeParameters">The multicode parameters.</param>
        /// <returns></returns>
        Task<List<Multicode>> GetAllMultiCodes(MultiCodeParameters multiCodeParameters);

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
