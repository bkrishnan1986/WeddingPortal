#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllOffersQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.Offers;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Offers
{
    /// <summary>
    /// Query for getting Offers
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllOffersQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Offers parameters.
        /// </summary>
        public OffersParameter OffersParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllOffersQuery"/> class.
        /// </summary>
        /// <param name="offersParameter">The Offers parameters.</param>
        public GetAllOffersQuery(OffersParameter offersParameter)
        {
            OffersParameter = offersParameter;
        }
    }
}
