#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | DeleteVendorSubscriptionCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceSubscriptions
{
    /// <summary>
    /// Command for deleting a ServiceSubscriptions
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteServiceSubscriptionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the ServiceSubscriptions identifier.
        /// </summary>
        public int ServiceSubscriptiontId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteServiceSubscriptionCommand"/> class.
        /// </summary>
        /// <param name="serviceSubscriptionRequestId">The ServiceSubscriptions identifier.</param>
        public DeleteServiceSubscriptionCommand(int serviceSubscriptionRequestId)
        {
            ServiceSubscriptiontId = serviceSubscriptionRequestId;
        }
    }
}

