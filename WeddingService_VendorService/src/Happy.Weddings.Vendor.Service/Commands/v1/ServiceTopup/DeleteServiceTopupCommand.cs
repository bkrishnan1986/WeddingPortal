#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | DeleteServiceTopupCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceTopup
{
    /// <summary>
    /// Command for deleting a ServiceTopup
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteServiceTopupCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the ServiceTopup identifier.
        /// </summary>
        public int ServiceTopupId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriptionPlanCommand"/> class.
        /// </summary>
        /// <param name="storyId">The ServiceTopup identifier.</param>
        public DeleteServiceTopupCommand(int servicetopupid)
        {
            ServiceTopupId = servicetopupid;
        }
    }
}
