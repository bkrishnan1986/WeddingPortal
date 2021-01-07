﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionPlan
{
    /// <summary>
    /// This Class is used to map Update SubscriptionPlan Request
    /// </summary>
    public class UpdateSubscriptionPlanRequest
    {
        public int? ParentsubscriptionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RegistrationFee { get; set; }
        public decimal ServiceFee { get; set; }
        public int? Gstpercentage { get; set; }
        public decimal TotalPrice { get; set; }
        public int Validity { get; set; }
        public int ValidityUnit { get; set; }
        public int ApprovalStatus { get; set; }
        public int UpdatedBy { get; set; }
    }
}
