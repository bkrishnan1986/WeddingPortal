#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S | Created and implemented.
//                                | UpdateMultiDetailsRequest 
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.MultiDetail
{
    public class UpdateMultidetailEcommerceRequest
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public int UpdatedBy { get; set; }
    }
}
