#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateBenefitCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Benefits;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Benefits
{
    /// <summary>
    /// Command for creating a Benefit
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateBenefitCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reqest.
        /// </summary>
        public CreateBenefitRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStoryCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateBenefitCommand(CreateBenefitRequest request)
        {
            Request = request;
        }
    }
}
