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

using System;

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.Orderreturn
{
    /// <summary>
    /// CreateOrderreturnRequest
    /// </summary>
    public class CreateOrderreturnRequest
    {
        public int OrderdetailId { get; set; }
        public string Reason { get; set; }
        public string Conclusion { get; set; }
        public int CreatedBy { get; set; }
    }
}
