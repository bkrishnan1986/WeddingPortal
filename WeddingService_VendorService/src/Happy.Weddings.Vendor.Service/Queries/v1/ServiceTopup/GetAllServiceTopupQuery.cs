﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  20-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllServiceTopupQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceTopup;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServiceTopup
{
    /// <summary>
    /// Query for getting ServiceTopup
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllServiceTopupQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the ServiceTopup parameters.
        /// </summary>
        public ServiceTopupParameter ServiceTopupParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSubscriptionplansQuery"/> class.
        /// </summary>
        /// <param name="serviceTopupParameter">The ServiceTopup parameters.</param>
        public GetAllServiceTopupQuery(ServiceTopupParameter serviceTopupParameter)
        {
            ServiceTopupParameter = serviceTopupParameter;
        }
    }
}
