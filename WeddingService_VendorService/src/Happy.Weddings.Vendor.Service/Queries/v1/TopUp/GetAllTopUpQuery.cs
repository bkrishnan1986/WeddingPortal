
#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllTopUpQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.TopUp;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.TopUp
{
    /// <summary>
    /// Query for getting TopUp
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllTopUpQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the TopUp parameters.
        /// </summary>
        public TopUpParameter TopUpParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTopUpQuery"/> class.
        /// </summary>
        /// <param name="vendorSubscriptionsParameter">The TopUp parameters.</param>
        public GetAllTopUpQuery(TopUpParameter vendorSubscriptionsParameter)
        {
            TopUpParameter = vendorSubscriptionsParameter;
        }
    }
}
