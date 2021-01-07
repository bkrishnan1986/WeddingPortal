#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateSubscriptionLocationCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionLocation
{
    /// <summary>
    /// Command for creating a SubscriptionLocation
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class CreateSubscriptionLocationCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateSubscriptionLocationRequest Request { get; set; }

        // public CreateSubscriptionBenefitRequest Request1 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionLocationCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateSubscriptionLocationCommand(CreateSubscriptionLocationRequest request)
        {
            Request = request;
        }
    }
}
