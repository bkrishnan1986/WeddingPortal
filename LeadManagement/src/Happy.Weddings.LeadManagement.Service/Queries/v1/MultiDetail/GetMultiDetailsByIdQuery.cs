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

#endregion File Header

using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.MultiDetail
{
    /// <summary>
    /// Query for getting mulidetail by Id
    /// </summary>
    /// 
    public class GetMultiDetailsByIdQuery  :  IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multicode identifier.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultiDetailsByIdQuery"/> class.
        /// </summary>
        /// <param name="multiCodeId"></param>

        public GetMultiDetailsByIdQuery(string multiCode)
        {
            Code = multiCode;
        }
    }
}
