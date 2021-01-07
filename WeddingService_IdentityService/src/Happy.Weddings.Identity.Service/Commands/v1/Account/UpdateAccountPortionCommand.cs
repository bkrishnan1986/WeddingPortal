#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateAccountPortionCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Requests.Account;

#endregion

namespace Happy.Weddings.Identity.Service.Commands.v1.Account
{
    /// <summary>
    /// Command class for update account portion.
    /// </summary>
    public class UpdateAccountPortionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateAccountsPortionRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAccountsPortionRequest"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="profileId">Profile Id</param>
        public UpdateAccountPortionCommand(UpdateAccountsPortionRequest request)
        {
            Request = request;
        }
    }
}
