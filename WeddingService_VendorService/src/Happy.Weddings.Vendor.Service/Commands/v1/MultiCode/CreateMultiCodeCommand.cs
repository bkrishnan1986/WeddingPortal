#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | CreateMultiCodeCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.MultiCode;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.MultiCode
{
    /// <summary>
    /// Command for creating a multicode
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateMultiCodeCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateMultiCodeRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultiCodeCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateMultiCodeCommand(CreateMultiCodeRequest request)
        {
            Request = request;
        }
    }
}
