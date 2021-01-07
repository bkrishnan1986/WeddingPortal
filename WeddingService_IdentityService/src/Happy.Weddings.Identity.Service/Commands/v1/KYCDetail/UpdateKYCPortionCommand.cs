#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  26-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateKYCPortionCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail;

#endregion

namespace Happy.Weddings.Identity.Service.Commands.v1.KYCDetail
{
    /// <summary>
    /// Command class for update KYC portion.
    /// </summary>
    public class UpdateKYCPortionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        /// <value>
        /// The profile identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateKYCPortionRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateKYCPortionCommand"/> class.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        public UpdateKYCPortionCommand(int profileId, UpdateKYCPortionRequest request)
        {
            Request = request;
            Id = profileId;
        }
    }
}
