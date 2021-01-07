﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetMultiDetailQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.MultiDetail
{
    /// <summary>
    /// Query for getting a multidetail
    /// </summary>
    public class GetMultiDetailQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multidetail identifier.
        /// </summary>
        public int MultiDetailId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultiDetailQuery"/> class.
        /// </summary>
        /// <param name="storyId">The multidetail identifier.</param>
        public GetMultiDetailQuery(int multidetailId)
        {
            MultiDetailId = multidetailId;
        }
    }
}
