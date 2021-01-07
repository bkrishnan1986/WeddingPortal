#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetMultiCodeQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Identity.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Identity.Service.Queries.v1.MultiCode
{
    /// <summary>
    /// Query for getting a Multicode
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Identity.Core.DTO.Responses.APIResponse}}" />
    /// 
    public class GetMultiCodeQuery  : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multicode identifier.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultiCodeQuery"/> class.
        /// </summary>
        /// <param name="multiCodeId"></param>
        public GetMultiCodeQuery(string code)
        {
            Code = code; 
        }            
    }
}
