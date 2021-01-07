#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetAccountDetailsQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Requests.Account;

#endregion

namespace Happy.Weddings.Identity.Service.Queries.v1.Account
{
    /// <summary>
    /// Query for getting a login details.
    /// </summary>
    public class GetAccountDetailsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Login parameters.
        /// </summary>
        public AccountParameters AccountParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountDetailsQuery"/> class.
        /// </summary>
        /// <param name="profileParameters">The Profile parameters.</param>
        public GetAccountDetailsQuery(AccountParameters loginParameters)
        {
            AccountParameters = loginParameters;
        }
    }
}
