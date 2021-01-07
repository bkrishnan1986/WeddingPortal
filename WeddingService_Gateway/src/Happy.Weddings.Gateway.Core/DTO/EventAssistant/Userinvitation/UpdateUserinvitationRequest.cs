﻿#region File Header

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

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Userinvitation
{
    /// <summary>
    /// This class is used to map UpdateMultiDetailRequest
    /// </summary>
    public class UpdateUserinvitationRequest
    {
        public int UserId { get; set; }
        public int InvitationId { get; set; }
        public int FieldId { get; set; }
        public string FieldAnswer { get; set; }
        public short Active { get; set; }
        public int UpdatedBy { get; set; }
    }
}
