#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | DeleteWalletDeductionCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.WalletDeduction
{
    /// <summary>
    /// Command for deleting a Wallet Deduction
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class DeleteWalletDeductionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Deduction identifier.
        /// </summary>
        /// <value>
        /// The Wallet Deduction identifier.
        /// </value>
        public int WalletDeductionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWalletDeductionCommand"/> class.
        /// </summary>
        /// <param name="walletDeductionId">The wWllet Deduction identifier.</param>
        public DeleteWalletDeductionCommand(int walletDeductionId)
        {
            WalletDeductionId = walletDeductionId;
        }
    }
}
