#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetAllMultiCodesQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Requests.MultiCode;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.MultiCode
{
    /// <summary>
    /// Query for getting multicodes
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetAllMultiCodesQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multicode parameters.
        /// </summary>
        public MultiCodeParameters MultiCodeParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultiCodesQuery"/> class.
        /// </summary>
        /// <param name="multiCodeParameters">The multicode parameters.</param>
        public GetAllMultiCodesQuery(MultiCodeParameters multiCodeParameters)
        {
            MultiCodeParameters = multiCodeParameters;
        }
    }
}
