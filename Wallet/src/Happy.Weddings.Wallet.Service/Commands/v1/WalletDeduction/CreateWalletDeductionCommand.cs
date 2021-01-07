#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletDeductionCommand --class
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
    /// Command for creating a Wallet Deduction
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreateWalletDeductionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateWalletDeductionRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWalletDeductionCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateWalletDeductionCommand(CreateWalletDeductionRequest request)
        {
            Request = request;
        }

    }
}
