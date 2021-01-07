#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Sep-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | ServiceAnswerDetails --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer
{
   public class ServiceAnswerDetails
    {
        public IEnumerable<UpdateServiceAnswerRequest> UpdateServiceAnswers { get; set; }
    }
}
