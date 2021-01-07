#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateWalletCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Wallet;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Wallet
{
    /// <summary>
    /// Command for creating a Wallet
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class CreateWalletCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateWalletRequest Request { get; set; }

        // public CreateSubscriptionBenefitRequest Request1 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWalletCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateWalletCommand(CreateWalletRequest request)
        {
            Request = request;
        }
    }
}