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

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.Productquantity
{
    /// <summary>
    ///  This class is used to map Create MultiDetail Request
    /// </summary>
    public class CreateProductquantitysRequest
    {
        public int ProductId { get; set; }
        public int LeftQty { get; set; }
        public int TotalQty { get; set; }
        public int CreatedBy { get; set; }
    }
}
