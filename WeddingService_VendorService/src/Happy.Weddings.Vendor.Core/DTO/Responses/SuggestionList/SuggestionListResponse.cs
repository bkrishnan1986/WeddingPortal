#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionPlansResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.SuggestionList
{
    /// <summary>
    /// This Class is used to map SubscriptionPlans Response
    /// </summary>

    public class SuggestionListResponse
    {                              
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int VendorId { get; set; }
        public string Description { get; set; }
        public int ApprovalStatus { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }


    }
}
