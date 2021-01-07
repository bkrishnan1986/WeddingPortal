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

using System;

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.Order
{
    /// <summary>
    /// This class is used to map UpdateMultiDetailRequest
    /// </summary>
    public class UpdateOrderRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Status { get; set; }
        public int Qty { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public short Active { get; set; }
        public int UpdatedBy { get; set; }
    }
}
