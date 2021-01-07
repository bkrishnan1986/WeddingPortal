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
using Happy.Weddings.Vendor.Core.Domain;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion
{
    public class ServiceQuestionServiceTypeParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceQuestionParameters"/> class.
        /// </summary>
        public ServiceQuestionServiceTypeParameters()
        {
            OrderBy = "ServiceType";
        }

        /// <summary>
        /// Gets or sets IsForVendor.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public bool IsForVendor { get; set; }

        /// <summary>
        /// Gets or sets the ServiceType.
        /// </summary>
        public int ServiceType { get; set; }
    }
}
