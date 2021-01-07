#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateServiceTopupCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header


using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceTopup;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceTopup
{
    /// <summary>
    /// Command for updating a ServiceTopup
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateServiceTopupCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the ServiceTopup identifier.
        /// </summary>
        /// <value>
        /// The ServiceTopup identifier.
        /// </value>
        public int ServiceTopupId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateServiceTopupRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionPlanCommand" /> class.
        /// </summary>
        /// <param name="serviceTopupId">The ServiceTopup identifier.</param>
        /// <param name="request">The request.</param>
        public UpdateServiceTopupCommand(int serviceTopupId, UpdateServiceTopupRequest request)
        {
            ServiceTopupId = serviceTopupId;
            Request = request;
        }
    }
}
