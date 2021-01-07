#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ReplyDataResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header


namespace Happy.Weddings.Vendor.Core.DTO.Responses.CommentReply
{
    public class ReplyDataResponse : CommentReplyResponse
    {
        public int Count { get; set; }
    }
}
