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

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Invitation
{
    /// <summary>
    ///  This class is used to map Create MultiDetail Request
    /// </summary>
    public class CreateInvitationRequest
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public float? Price { get; set; }
        public int CreatedBy { get; set; }
    }
}
