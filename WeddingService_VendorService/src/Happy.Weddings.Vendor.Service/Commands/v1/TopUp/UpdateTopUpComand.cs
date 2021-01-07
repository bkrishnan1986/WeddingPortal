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

using Happy.Weddings.Vendor.Core.DTO.Requests.TopUp;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.TopUp
{
    /// <summary>
    /// Command for updating a TopUp
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateTopUpCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the TopUp identifier.
        /// </summary>
        /// <value>
        /// The story identifier.
        /// </value>
        public int TopupId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateTopUpRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionBenefitCommand" /> class.
        /// </summary>
        /// <param name="topupId">The TopUp identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateTopUpCommand(int topupId, UpdateTopUpRequest request)
        {
            TopupId = topupId;
            Request = request;
        }
    }
}
