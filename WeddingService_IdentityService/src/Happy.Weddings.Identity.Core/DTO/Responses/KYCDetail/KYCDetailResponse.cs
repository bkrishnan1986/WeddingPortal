#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | KYCDetailResponse class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;
using Happy.Weddings.Identity.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail
{
    public class KYCDetailResponse : KYCDataResponse
    {
        public List<KycDetailsDTO> Kycdetails { get; set; }

        public List<GstDetailsDTO> Gstdetails { get; set; }
    }
}
