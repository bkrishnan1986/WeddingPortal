#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | SearchFromAllServicesQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Service;
using MediatR;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.Service
{
    public class SearchFromAllServicesQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the search parameters.
        /// </summary>
        /// <value>
        /// The search parameters.
        /// </value>
        public SearchParameters searchParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchFromAllServicesQuery"/> class.
        /// </summary>
        /// <param name="searchParameters">The search parameters.</param>
        public SearchFromAllServicesQuery(SearchParameters searchParameters)
        {
            this.searchParameters = searchParameters;
        }
    }
}
