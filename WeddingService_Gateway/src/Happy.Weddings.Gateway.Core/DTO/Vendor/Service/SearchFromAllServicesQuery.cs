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


namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Service
{
    public class SearchFromAllServicesQuery 
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
