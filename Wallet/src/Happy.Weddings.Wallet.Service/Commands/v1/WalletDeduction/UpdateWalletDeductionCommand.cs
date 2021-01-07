#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateWalletDeductionCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.WalletDeduction
{
    /// <summary>
    /// Command for updating a Wallet Deduction
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateWalletDeductionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Deduction identifier.
        /// </summary>
        /// <value>
        /// The Wallet Deduction identifier.
        /// </value>
        public int WalletDeductionId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateWalletDeductionRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWalletDeductionCommand" /> class.
        /// </summary>
        /// <param name="walletDeductionId">The Wallet Deduction identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateWalletDeductionCommand(int walletDeductionId, UpdateWalletDeductionRequest request)
        {
            WalletDeductionId = walletDeductionId;
            Request = request;
        }
    }
}
