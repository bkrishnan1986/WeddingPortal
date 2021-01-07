#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateBenefitCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Benefits
{
    /// <summary>
    /// Command for deleting a Benefit
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteBenefitCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Benefits identifier.
        /// </summary>
        public int BenefitId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBenefitsCommand"/> class.
        /// </summary>
        /// <param name="benefitId">The Benefit identifier.</param>
        public DeleteBenefitCommand(int benefitId)
        {
            BenefitId = benefitId;
        }
    }
}
