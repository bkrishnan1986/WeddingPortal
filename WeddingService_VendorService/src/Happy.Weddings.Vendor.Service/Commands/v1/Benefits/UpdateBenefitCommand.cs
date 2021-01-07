#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateBenefitsCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Benefits;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Benefits
{
    /// <summary>
    /// Command for updating a Benefit
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateBenefitsCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Benefits identifier.
        /// </summary>
        /// <value>
        /// The Benefit identifier.
        /// </value>
        public int BenefitId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateBenefitRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBenefitsRequest" /> class.
        /// </summary>
        /// <param name="benefitId">The story identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateBenefitsCommand(int benefitId, UpdateBenefitRequest request)
        {
            BenefitId = benefitId;
            Request = request;
        }
    }
}
