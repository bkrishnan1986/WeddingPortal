#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Profile.Lead
{
    public class LeadDataCollectionResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadDataCollectionResponseProfile"/> class.
        /// </summary>
        public LeadDataCollectionResponseProfile()
        {
            CreateMap<Leaddatacollection, LeadDataCollectionResponse>();
        }
    }
}