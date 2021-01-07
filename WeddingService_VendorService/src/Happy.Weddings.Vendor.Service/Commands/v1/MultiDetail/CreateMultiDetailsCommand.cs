#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | CreateMultiDetailsCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.MultiDetail
{
    /// <summary>
    /// Command for creating a MultiDetail
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateMultiDetailsCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateMultiDetailsRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultiDetailsCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateMultiDetailsCommand(CreateMultiDetailsRequest request)
        {
            Request = request;
        }
    }
}
