#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S | Created and implemented.
//                                | MultiDetailParameters 
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Gateway.Core.DTO;
using System;

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.MultiDetail
{
    public class MultidetailParameter
    {
        public int Value { get; set; }
        public bool IsForSingleData { get; set; }
        public bool IsForMultiCode { get; set; }
    }
}

