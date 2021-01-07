#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | DeleteSubscriptionLocationCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionLocation
{
    /// <summary>
    /// Command for deleting a Subscription Plan
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteSubscriptionLocationCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubscriptionLocation identifier.
        /// </summary>
        public int SubscriptionLocationId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriptionLocationCommand"/> class.
        /// </summary>
        /// <param name="subscriptionLocationId">The SubscriptionLocation identifier.</param>
        public DeleteSubscriptionLocationCommand(int subscriptionLocationId)
        {
            SubscriptionLocationId = subscriptionLocationId;
        }
    }
}
