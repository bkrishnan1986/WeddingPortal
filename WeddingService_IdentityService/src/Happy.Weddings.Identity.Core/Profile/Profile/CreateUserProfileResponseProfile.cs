#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateUserProfileResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Profile
{
    /// <summary>
    /// Automapper profile for create user profile out response.
    /// </summary>
    public class CreateUserProfileResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserProfileResponseProfile"/> class.
        /// </summary>
        public CreateUserProfileResponseProfile()
        {
            CreateMap<Entity.Profile, ProfileResponse>()
                .ForMember(x => x.CountryName, opt => opt.MapFrom(o => o.CountryNavigation != null ? o.CountryNavigation.Value : ""))
                .ForMember(x => x.StateName, opt => opt.MapFrom(o => o.StateNavigation != null ? o.StateNavigation.Value : ""))
                .ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(o => o.ApprovalStatusNavigation != null ? o.ApprovalStatusNavigation.Value : ""))
                .ForMember(x => x.GenderName, opt => opt.MapFrom(o => o.GenderNavigation != null ? o.GenderNavigation.Value : ""))
                .ForMember(x => x.DistrictName, opt => opt.MapFrom(o => o.DistrictNavigation != null ? o.DistrictNavigation.Value : ""))
                .ForMember(x => x.ProfileStatusName, opt => opt.MapFrom(o => o.ProfileStatusNavigation != null ? o.ProfileStatusNavigation.Value : ""))
                .ForMember(x => x.RoleName, opt => opt.MapFrom(o => o.RoleNavigation != null ? o.RoleNavigation.Value : ""));

            CreateMap<Entity.Companydistricts, CompanyDistrictsDTO>()
                .ForMember(x => x.DistrictName, opt => opt.MapFrom(o => o.DistrictNavigation != null ? o.DistrictNavigation.Value : ""));

            CreateMap<Entity.Profilepermission, ProfilePermissionDTO>()
                .ForMember(x => x.RoleName, opt => opt.MapFrom(o => o.Role != null ? o.Role.Value : ""));
        }
    }
}
