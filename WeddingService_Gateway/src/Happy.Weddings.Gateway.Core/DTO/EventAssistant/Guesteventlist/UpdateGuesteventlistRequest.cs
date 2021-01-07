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

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Guesteventlist
{
    /// <summary>
    /// This class is used to map UpdateMultiDetailRequest
    /// </summary>
    public class UpdateGuesteventlistRequest
    {

        public string EventTitle { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string VenueName { get; set; }
        public string Attire { get; set; }
        public string Description { get; set; }
        public int? Rsvpstatus { get; set; }
        public short? Active { get; set; }
        public int? CreatedBy { get; set; }
    }
}
