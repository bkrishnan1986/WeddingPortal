﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | ServiceResponse class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Service
{
    public class ServiceResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        public int ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>
        /// The name of the service.
        /// </value>
        public string ServiceName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        public decimal? Experience { get; set; }
        /// <summary>
        /// Gets or sets the experience unit.
        /// </summary>
        /// <value>
        /// The experience unit.
        /// </value>
        public int? ExperienceUnit { get; set; }
        /// <summary>
        /// Gets or sets the award.
        /// </summary>
        /// <value>
        /// The award.
        /// </value>
        public string Award { get; set; }

        public string PhotoPath { get; set; }
        /// <summary>
        /// Gets or sets the type of the rate.
        /// </summary>
        /// <value>
        /// The type of the rate.
        /// </value>
        public int? RateType { get; set; }
        /// <summary>
        /// Gets or sets the price range start.
        /// </summary>
        /// <value>
        /// The price range start.
        /// </value>
        public decimal? PriceRangeStart { get; set; }
        /// <summary>
        /// Gets or sets the price range end.
        /// </summary>
        /// <value>
        /// The price range end.
        /// </value>
        public decimal? PriceRangeEnd { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public int? Currency { get; set; }
        public string CurrencyName { get; set; }
        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets the name of the vendor.
        /// </summary>
        /// <value>
        /// The name of the vendor.
        /// </value>
        public string VendorName { get; set; }
        /// <summary>
        /// Gets or sets the vendor status.
        /// </summary>
        /// <value>
        /// The vendor status.
        /// </value>
        public int? VendorStatus { get; set; }
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public byte Active { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }

    }
}
