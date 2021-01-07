#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetAllMultiDetailsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.MultiDetail
{
    /// <summary>
    /// Query for getting multidetails
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllMultiDetailsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multicode parameters.
        /// </summary>
        public MultiDetailParameters MultiDetailParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultiCodeQuery"/> class.
        /// </summary>
        /// <param name="storyParameters">The multidetail parameters.</param>
        public GetAllMultiDetailsQuery(MultiDetailParameters multiDetailParameters)
        {
            MultiDetailParameters = multiDetailParameters;
        }
    }
}
