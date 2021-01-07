#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateServiceTopupCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceTopup;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceTopup
{
    /// <summary>
    /// Command for creating a ServiceTopup
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class CreateServiceTopupCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        public CreateServiceTopupRequest Request { get; set; }

        // public CreateSubscriptionBenefitRequest Request1 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceTopupCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        // public CreateSubscriptionPlanCommand(CreateSubscriptionPlanRequest request, CreateSubscriptionBenefitRequest request1)
        public CreateServiceTopupCommand(CreateServiceTopupRequest request)
        {
            Request = request;
        }
    }
}
