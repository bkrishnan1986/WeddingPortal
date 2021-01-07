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
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Userinvitation
{
    /// <summary>
    ///   This class is used to map MultiDetail Response
    /// </summary>
    public class UserinvitationResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int InvitationId { get; set; }
        public int FieldId { get; set; }
        public string FieldAnswer { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
   
}
