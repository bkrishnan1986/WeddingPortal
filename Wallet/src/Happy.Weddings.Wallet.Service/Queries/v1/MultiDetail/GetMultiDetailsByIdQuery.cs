#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetMultiDetailsByIdQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.MultiDetail
{
    /// <summary>
    /// Query for getting mulidetail by Id
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    /// 
    public class GetMultiDetailsByIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multicode identifier.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultiDetailsByIdQuery"/> class.
        /// </summary>
        /// <param name="code"></param>
        public GetMultiDetailsByIdQuery(string code)
        {
            Code = code;
        }
    }
}
