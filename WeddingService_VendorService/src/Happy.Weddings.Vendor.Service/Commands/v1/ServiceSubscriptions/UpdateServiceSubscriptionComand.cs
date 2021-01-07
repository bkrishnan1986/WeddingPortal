#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateVendorSubscriptionCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceSubscriptions
{
    /// <summary>
    /// Command for updating a SubscriptionBenefits
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateServiceSubscriptionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the ServiceSubscriptions identifier.
        /// </summary>
        /// <value>
        /// The story identifier.
        /// </value>
        public int ServiceSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateServiceSubscriptionRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionBenefitCommand" /> class.
        /// </summary>
        /// <param name="serviceSubscriptionId">The story identifier.</param>
        /// <param name="request">The request.</param>
        public UpdateServiceSubscriptionCommand(int serviceSubscriptionId, UpdateServiceSubscriptionRequest request)
        {
            ServiceSubscriptionId = serviceSubscriptionId;
            Request = request;
        }
    }
}
