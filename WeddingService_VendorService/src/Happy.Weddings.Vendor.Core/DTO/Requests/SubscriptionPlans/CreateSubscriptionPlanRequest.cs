#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateSubscriptionPlanRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionPlans
{
    /// <summary>
    /// This Class is used to map Create SubscriptionPlan Request
    /// </summary>
    public class CreateSubscriptionPlanRequest
    {
        public int? ParentsubscriptionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Mode { get; set; }
        public decimal RegistrationFee { get; set; }
        public decimal ServiceFee { get; set; }
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
        public int Validity { get; set; }
        public int ValidityUnit { get; set; }
        public int ApprovalStatus { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }

        public List<SubscriptionBenefit> SubscriptionBenefit { get; set; }
    }
    public class SubscriptionBenefit
    {
        public int SubscriptionId { get; set; }
        public int Benefit { get; set; }
        public int? Count { get; set; }
        public int ApprovalStatus { get; set; }
        public int CreatedBy { get; set; }

    }
}
