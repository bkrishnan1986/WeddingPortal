#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Aug-2020 |    REJI SALOOJA B S    | Created and implemented. 
//              |                         | MultiDetailResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Newtonsoft.Json;
using System;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Invitation
{
    /// <summary>
    ///   This class is used to map MultiDetail Response
    /// </summary>
    public class InvitationResponse
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public float? Price { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
