#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Sep-2020 |    Reji Salooja B  S  | Created and implemented. 
//              |                       | ServiceAnswerRequest   class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer
{
    public class ServiceAnswerRequest 
    {
        public IEnumerable<CreateServiceAnswerRequest> ServiceAnswers { get; set; }
    }
}
