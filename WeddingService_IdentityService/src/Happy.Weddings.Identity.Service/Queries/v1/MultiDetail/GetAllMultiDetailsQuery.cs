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

#endregion

using Happy.Weddings.Identity.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.Identity.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Identity.Service.Queries.v1.MultiDetail
{
    /// <summary>
    /// Query for getting All multidetails
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Identity.Core.DTO.Responses.APIResponse}}" />
    public class GetAllMultiDetailsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multidetail parameters.
        /// </summary>
        public MultiDetailParameters MultiDetailParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultiDetailsQuery"/> class.
        /// </summary>
        /// <param name="multiDetailParameters">The multidetail parameters.</param>
        public GetAllMultiDetailsQuery(MultiDetailParameters multiDetailParameters)
        {
            MultiDetailParameters = multiDetailParameters;
        }
    }
}
