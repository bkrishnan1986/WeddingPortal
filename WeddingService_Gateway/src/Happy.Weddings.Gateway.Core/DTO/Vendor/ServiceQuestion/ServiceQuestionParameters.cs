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

using System;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceQuestion
{
    public class ServiceQuestionParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceQuestionParameters"/> class.
        /// </summary>
        public ServiceQuestionParameters()
        {
          //  OrderBy = "ServiceType";
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }    
        public string SearchKeyword { get; set; }
        public bool IsForVendor { get; set; }
    }
}
