#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateKYCDataCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail;

#endregion

namespace Happy.Weddings.Identity.Service.Commands.v1.KYCDetail
{
    /// <summary>
    /// Command class for create user class.
    /// </summary>
    public class CreateKYCDataCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateKYCDataRequest Request { get; set; }

        public int ProfileId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateKYCDataCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateKYCDataCommand(int profileId,CreateKYCDataRequest request)
        {
            Request = request;
            ProfileId = profileId;
        }
    }
}
