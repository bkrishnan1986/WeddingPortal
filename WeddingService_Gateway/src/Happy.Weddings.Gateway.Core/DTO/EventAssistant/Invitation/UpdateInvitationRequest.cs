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

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Invitation
{
    /// <summary>
    /// This class is used to map UpdateMultiDetailRequest
    /// </summary>
    public class UpdateInvitationRequest
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public float? Price { get; set; }
        public int UpdatedBy { get; set; }

    }
}
