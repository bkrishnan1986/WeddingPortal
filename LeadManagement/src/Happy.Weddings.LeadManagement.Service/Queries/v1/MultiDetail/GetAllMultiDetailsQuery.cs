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

using Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.MultiDetail
{
    /// <summary>
    /// Query for getting multidetails
    /// </summary>
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
