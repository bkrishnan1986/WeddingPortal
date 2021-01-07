#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetAllMultiCodesQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiCode;
using MediatR;

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.MultiCode
{
    /// <summary>
    /// Query for getting multicodes
    /// </summary>
    public class GetAllMultiCodesQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multicode parameters.
        /// </summary>
        public MultiCodeParameters MultiCodeParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultiCodesQuery"/> class.
        /// </summary>
        /// <param name="storyParameters">The multicode parameters.</param>
        public GetAllMultiCodesQuery(MultiCodeParameters multiCodeParameters)
        {
            MultiCodeParameters = multiCodeParameters;
        }
    }
}
