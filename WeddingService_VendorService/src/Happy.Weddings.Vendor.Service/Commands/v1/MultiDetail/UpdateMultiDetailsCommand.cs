﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | UpdateMultiDetailsCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.MultiDetail
{
    /// <summary>
    /// Command for updating a MultiDetail
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateMultiDetailsCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multidetail identifier.
        /// </summary>
        /// <value>
        /// The multidetail identifier.
        /// </value>
        public int MultiDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateMultiDetailsRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultiDetailsCommand" /> class.
        /// </summary>
        /// <param name="multicodeId">The multidetail identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateMultiDetailsCommand(int multidetailId, UpdateMultiDetailsRequest request)
        {
            MultiDetailId = multidetailId;
            Request = request;
        }
    }
}
