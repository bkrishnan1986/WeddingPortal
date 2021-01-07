#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | IRefundRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.Refund;
using Happy.Weddings.Wallet.Core.Entity;
using System.Threading.Tasks;
using Happy.Weddings.Wallet.Core.DTO.Responses.Refund;

namespace Happy.Weddings.Wallet.Core.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the Refund.
    /// </summary>
    public interface IRefundRepository : IRepositoryBase<Refund>
    {
        /// <summary>
        /// Gets all Refund
        /// </summary>
        /// <param name="refundParameter">The Refund parameters.</param>
        /// <returns></returns>
        Task<List<RefundResponse>> GetAllRefund(RefundParameter refundParameter);

        /// <summary>
        /// Gets the Refund by identifier.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <returns></returns>
        Task<Refund> GetRefundById(int refundId);

        /// <summary>
        /// Gets the refunds by identifier.
        /// </summary>
        /// <param name="refundId">The refund identifier.</param>
        /// <returns></returns>
        Task<List<RefundResponse>> GetRefundsById(int refundId);

        /// <summary>
        /// Creates the Refund
        /// </summary>
        /// <param name="refund">The Refund.</param>
        void CreateRefund(Refund refund);

        /// <summary>
        /// Updates the Refund.
        /// </summary>
        /// <param name="refund">The Refund.</param>
        void UpdateRefund(Refund refund);
    }
}
