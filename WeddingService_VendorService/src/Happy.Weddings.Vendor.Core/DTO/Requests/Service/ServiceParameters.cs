﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | ServicesParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Service
{

    public class ServicesParameters 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesParameters"/> class.
        /// </summary>
        public ServicesParameters()
        {
           // OrderBy = "Title";
        }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
      // public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
       // public DateTime? ToDate { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        //public string SearchKeyword { get; set; }
    }
}

