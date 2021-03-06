﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateTopUpRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.TopUp
{
    /// <summary>
    /// This Class is used to map CreateVendorSubscriptionRequest
    /// </summary>
    public class CreateTopUpRequest
    {
        public int TopUpType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Mode { get; set; }
        public decimal Price { get; set; }
        public int? CgstRatePercentage { get; set; }
        public decimal? Cgstamount { get; set; }
        public int? SgstRatePercentage { get; set; }
        public decimal? Sgstamount { get; set; }
        public int? IgstRatePercentage { get; set; }
        public decimal? Igstamount { get; set; }
        public int? GstRatePercentage { get; set; }
        public decimal? Gstamount { get; set; }
        public decimal? Cplamount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
    }
}