#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetKYCDataQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;

#endregion

namespace Happy.Weddings.Identity.Service.Queries.v1.KYCDetail
{
    /// <summary>
    /// Query for getting a KYC
    /// </summary>
    public class GetKYCDataQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Profile identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetKYCDataQuery"/> class.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        public GetKYCDataQuery(int profileId)
        {
            Id = profileId;
        }
    }
}
