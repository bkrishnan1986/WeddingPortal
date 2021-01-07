#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadQuoteParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.Domain;
using System;

#endregion

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class LeadQuoteParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadQuoteParameters"/> class.
        /// </summary>
        public LeadQuoteParameters()
        {
            OrderBy = "EventDate";
        }

        ///// <summary>
        ///// Gets or sets from date.
        ///// </summary>
        //public DateTime? FromDate { get; set; }

        ///// <summary>
        ///// Gets or sets to date.
        ///// </summary>
        //public DateTime? ToDate { get; set; }

        ///// <summary>
        ///// Gets or sets the search keyword.
        ///// </summary>
        //public string SearchKeyword { get; set; }

        ///// <summary>
        ///// Gets or sets the value for search keyword.
        ///// </summary>
        //public string Value { get; set; }

    }
}
