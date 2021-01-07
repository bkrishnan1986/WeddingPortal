#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllBenefitsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.Benefits;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Benefits
{
    /// <summary>
    /// Query for getting Benefits
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllBenefitsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Benefits parameters.
        /// </summary>
        public BenefitsParameter BenefitsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllBenefitsQuery"/> class.
        /// </summary>
        /// <param name="offersParameter">The Benefits parameters.</param>
        public GetAllBenefitsQuery(BenefitsParameter benefitsParameter)
        {
            BenefitsParameter = benefitsParameter;
        }
    }
}
