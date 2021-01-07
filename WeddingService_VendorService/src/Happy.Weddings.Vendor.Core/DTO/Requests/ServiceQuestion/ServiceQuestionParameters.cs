#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 | ServiceQuestionParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header    

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion
{
    public class ServiceQuestionParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceQuestionParameters"/> class.
        /// </summary>
        public ServiceQuestionParameters()
        {
         //   OrderBy = "ServiceType";
        }    

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        public string SearchKeyword { get; set; }
        public bool IsForVendor { get; set; }
    }
}
