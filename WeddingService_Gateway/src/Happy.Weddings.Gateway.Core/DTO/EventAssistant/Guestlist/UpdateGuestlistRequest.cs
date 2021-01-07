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

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Guestlist
{
    /// <summary>
    /// This class is used to map UpdateMultiDetailRequest
    /// </summary>
    public class UpdateGuestlistRequest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Apt { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Pincode { get; set; }
        public string Country { get; set; }
        public double? PhoneNo { get; set; }
        public string Guestlistcol { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
