#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S | Created and implemented.
// |                              | CreateMultiDetailsRequest 
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.MultiDetail
{
    public class CreateMultidetailEcommerceRequest
    {
        public int MultiCodeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
    }
}
