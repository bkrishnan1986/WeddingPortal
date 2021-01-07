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
    public class LeadResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadResponseProfile"/> class.
        /// </summary>
        public LeadResponseProfile()
        {
            CreateMap<Leads, LeadsResponse>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.CategoryNavigation != null ? x.CategoryNavigation.Value : ""))
                .ForMember(x => x.EventTypeName, opt => opt.MapFrom(o => o.EventTypeNavigation != null ? o.EventTypeNavigation.Value : ""))
                .ForMember(x => x.LeadModeName, opt => opt.MapFrom(o => o.LeadModeNavigation != null ? o.LeadModeNavigation.Value : ""))
                .ForMember(x => x.LeadStatusName, opt => opt.MapFrom(o => o.Status != null ? o.Status.Value : ""))
                .ForMember(x => x.LeadTypeName, opt => opt.MapFrom(o => o.LeadTypeNavigation != null ? o.LeadTypeNavigation.Value : ""))
                .ForMember(x => x.WalletStatusName, opt => opt.MapFrom(o => o.WalletStatusNavigation != null ? o.WalletStatusNavigation.Value : ""))
                .ForMember(x => x.CustomerName, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerName : ""))
                .ForMember(x => x.CustomerPhone1, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerPhone1 : ""))
                .ForMember(x => x.CustomerPhone2, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerPhone2 : ""))
                .ForMember(x => x.EventLocationName, opt => opt.MapFrom(o => o.EventLocationNavigation != null ? o.EventLocationNavigation.Value : ""))
                .ForMember(x => x.CustomerEmail, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerEmail : ""))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerId : ""));

            CreateMap<Leads, LeadsResponse1>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.CategoryNavigation != null ? x.CategoryNavigation.Value : ""))
                .ForMember(x => x.EventTypeName, opt => opt.MapFrom(o => o.EventTypeNavigation != null ? o.EventTypeNavigation.Value : ""))
                .ForMember(x => x.LeadModeName, opt => opt.MapFrom(o => o.LeadModeNavigation != null ? o.LeadModeNavigation.Value : ""))
                .ForMember(x => x.LeadStatusName, opt => opt.MapFrom(o => o.Status != null ? o.Status.Value : ""))
                .ForMember(x => x.LeadTypeName, opt => opt.MapFrom(o => o.LeadTypeNavigation != null ? o.LeadTypeNavigation.Value : ""))
                .ForMember(x => x.WalletStatusName, opt => opt.MapFrom(o => o.WalletStatusNavigation != null ? o.WalletStatusNavigation.Value : ""))
                .ForMember(x => x.CustomerName, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerName : ""))
                .ForMember(x => x.CustomerPhone, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerPhone1 : ""))
                .ForMember(x => x.EventLocationName, opt => opt.MapFrom(o => o.EventLocationNavigation != null ? o.EventLocationNavigation.Value : ""))
                .ForMember(x => x.CustomerEmail, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerEmail : ""))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(o => o.DataCollection != null ? o.DataCollection.CustomerId : ""));

        }
    }
}