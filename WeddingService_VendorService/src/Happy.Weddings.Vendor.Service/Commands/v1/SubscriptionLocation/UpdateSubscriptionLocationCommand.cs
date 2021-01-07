#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSubscriptionPlanCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header


using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionLocation
{
    /// <summary>
    /// Command for updating a SubscriptionLocation
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateSubscriptionLocationCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubscriptionLocation identifier.
        /// </summary>
        /// <value>
        /// The story identifier.
        /// </value>
        public int SubscriptionLocationId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateSubscriptionLocationRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionLocationCommand" /> class.
        /// </summary>
        /// <param name="subscriptionLocationId">The SubscriptionLocation identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateSubscriptionLocationCommand(int subscriptionLocationId, UpdateSubscriptionLocationRequest request)
        {
            SubscriptionLocationId = subscriptionLocationId;
            Request = request;
        }
    }
}
