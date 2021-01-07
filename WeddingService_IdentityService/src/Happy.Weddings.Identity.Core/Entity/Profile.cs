using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Profile
    {
        public Profile()
        {
            Companydistricts = new HashSet<Companydistricts>();
            Kycdata = new HashSet<Kycdata>();
            Profileapprovalstatus = new HashSet<Profileapprovalstatus>();
            Profilepermission = new HashSet<Profilepermission>();
            Profilestatuses = new HashSet<Profilestatus>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryMobileNumber { get; set; }
        public string Email { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Aadhar { get; set; }
        public string Pan { get; set; }
        public string BankAccountNumber { get; set; }
        public string Ifsc { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyLogo { get; set; }
        public short Active { get; set; }
        public int? ApprovalStatus { get; set; }
        public int? ProfileStatus { get; set; }
        public string SecondaryMobileNumber { get; set; }
        public string ListingName { get; set; }
        public string ListingAddress { get; set; }
        public string ListingPincode { get; set; }
        public string Website { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string PintrestLink { get; set; }
        public string TwitterHandle { get; set; }
        public int? District { get; set; }
        public string PrimaryContactPerson { get; set; }
        public string CompanyPincode { get; set; }
        public string GoogleProfile { get; set; }
        public string UserId { get; set; }
        public string EmployeeId { get; set; }
        public string Otp { get; set; }
        public short IsPhoneVerified { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail ApprovalStatusNavigation { get; set; }
        public virtual Multidetail CountryNavigation { get; set; }
        public virtual Multidetail DistrictNavigation { get; set; }
        public virtual Multidetail GenderNavigation { get; set; }
        public virtual Multidetail ProfileStatusNavigation { get; set; }
        public virtual Multidetail RoleNavigation { get; set; }
        public virtual Multidetail StateNavigation { get; set; }
        public virtual ICollection<Companydistricts> Companydistricts { get; set; }
        public virtual ICollection<Kycdata> Kycdata { get; set; }
        public virtual ICollection<Profileapprovalstatus> Profileapprovalstatus { get; set; }
        public virtual ICollection<Profilepermission> Profilepermission { get; set; }
        public virtual ICollection<Profilestatus> Profilestatuses { get; set; }
    }
}
