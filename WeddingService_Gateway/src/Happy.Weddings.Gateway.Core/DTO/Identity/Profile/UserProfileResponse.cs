#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UserProfileResponse class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Profile
{
    /// <summary>
    /// User profile response class/model.
    /// </summary>
    public class UserProfileResponse
    { /// <summary>
      /// Gets or sets the identifier.
      /// </summary>
      /// <value>
      /// The identifier.
      /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the primary mobile number.
        /// </summary>
        /// <value>
        /// The primary mobile number.
        /// </value>
        public string PrimaryMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public int? Country { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public int? State { get; set; }

        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        /// <value>
        /// The name of the state.
        /// </value>
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public int? Gender { get; set; }

        /// <summary>
        /// Gets or sets the name of the gender.
        /// </summary>
        /// <value>
        /// The name of the gender.
        /// </value>
        public string GenderName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>
        /// The photo.
        /// </value>
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public int Role { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the aadhar.
        /// </summary>
        /// <value>
        /// The aadhar.
        /// </value>
        public string Aadhar { get; set; }

        /// <summary>
        /// Gets or sets the pan.
        /// </summary>
        /// <value>
        /// The pan.
        /// </value>
        public string Pan { get; set; }

        /// <summary>
        /// Gets or sets the bank account number.
        /// </summary>
        /// <value>
        /// The bank account number.
        /// </value>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the ifsc.
        /// </summary>
        /// <value>
        /// The ifsc.
        /// </value>
        public string Ifsc { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company code.
        /// </summary>
        /// <value>
        /// The company code.
        /// </value>
        public string CompanyCode { get; set; }

        /// <summary>
        /// Gets or sets the company logo.
        /// </summary>
        /// <value>
        /// The company logo.
        /// </value>
        public string CompanyLogo { get; set; }

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int? ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the name of the approval status.
        /// </summary>
        /// <value>
        /// The name of the approval status.
        /// </value>
        public string ApprovalStatusName { get; set; }

        /// <summary>
        /// Gets or sets the secondary mobile number.
        /// </summary>
        /// <value>
        /// The secondary mobile number.
        /// </value>
        public string SecondaryMobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the listing.
        /// </summary>
        /// <value>
        /// The name of the listing.
        /// </value>
        public string ListingName { get; set; }

        /// <summary>
        /// Gets or sets the listing address.
        /// </summary>
        /// <value>
        /// The listing address.
        /// </value>
        public string ListingAddress { get; set; }

        /// <summary>
        /// Gets or sets the listing pincode.
        /// </summary>
        /// <value>
        /// The listing pincode.
        /// </value>
        public string ListingPincode { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the facebook link.
        /// </summary>
        /// <value>
        /// The facebook link.
        /// </value>
        public string FacebookLink { get; set; }

        /// <summary>
        /// Gets or sets the instagram link.
        /// </summary>
        /// <value>
        /// The instagram link.
        /// </value>
        public string InstagramLink { get; set; }

        /// <summary>
        /// Gets or sets the pintrest link.
        /// </summary>
        /// <value>
        /// The pintrest link.
        /// </value>
        public string PintrestLink { get; set; }

        /// <summary>
        /// Gets or sets the twitter handle.
        /// </summary>
        /// <value>
        /// The twitter handle.
        /// </value>
        public string TwitterHandle { get; set; }

        /// <summary>
        /// Gets or sets the district.
        /// </summary>
        /// <value>
        /// The district.
        /// </value>
        public int? District { get; set; }

        /// <summary>
        /// Gets or sets the name of the district.
        /// </summary>
        /// <value>
        /// The name of the district.
        /// </value>
        public string DistrictName { get; set; }

        /// <summary>
        /// Gets or sets the primary contact person.
        /// </summary>
        /// <value>
        /// The primary contact person.
        /// </value>
        public string PrimaryContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the company pincode.
        /// </summary>
        /// <value>
        /// The company pincode.
        /// </value>
        public string CompanyPincode { get; set; }

        /// <summary>
        /// Gets or sets the google profile.
        /// </summary>
        /// <value>
        /// The google profile.
        /// </value>
        public string GoogleProfile { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
    }

    public class ProfileResponse : UserProfileResponse
    {
        public List<ProfilePermissionResponse> Profilepermission { get; set; }

        public List<CompanyDistrictResponse> CompanyDistricts { get; set; }
    }

    public class ProfilePermissionResponse
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string ProfilePermissions { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }

    public class CompanyDistrictResponse
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int District { get; set; }
        public string DistrictName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
