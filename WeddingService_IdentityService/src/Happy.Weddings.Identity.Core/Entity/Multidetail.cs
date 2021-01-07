using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Multidetail
    {
        public Multidetail()
        {
            Companydistricts = new HashSet<Companydistricts>();
            GstdetailsGstcityNavigation = new HashSet<Gstdetails>();
            GstdetailsGststateNavigation = new HashSet<Gstdetails>();
            KycdataKyc = new HashSet<Kycdata>();
            KycdataKycstatusNavigation = new HashSet<Kycdata>();
            ProfileApprovalStatusNavigation = new HashSet<Profile>();
            ProfileCountryNavigation = new HashSet<Profile>();
            ProfileDistrictNavigation = new HashSet<Profile>();
            ProfileGenderNavigation = new HashSet<Profile>();
            ProfileProfileStatusNavigation = new HashSet<Profile>();
            ProfileRoleNavigation = new HashSet<Profile>();
            ProfileStateNavigation = new HashSet<Profile>();
            Profileapprovalstatus = new HashSet<Profileapprovalstatus>();
            Profilepermission = new HashSet<Profilepermission>();
            Profilestatus = new HashSet<Profilestatus>();
            Rolesettings = new HashSet<Rolesettings>();
        }

        public int Id { get; set; }
        public int MultiCodeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multicode MultiCode { get; set; }
        public virtual ICollection<Companydistricts> Companydistricts { get; set; }
        public virtual ICollection<Gstdetails> GstdetailsGstcityNavigation { get; set; }
        public virtual ICollection<Gstdetails> GstdetailsGststateNavigation { get; set; }
        public virtual ICollection<Kycdata> KycdataKyc { get; set; }
        public virtual ICollection<Kycdata> KycdataKycstatusNavigation { get; set; }
        public virtual ICollection<Profile> ProfileApprovalStatusNavigation { get; set; }
        public virtual ICollection<Profile> ProfileCountryNavigation { get; set; }
        public virtual ICollection<Profile> ProfileDistrictNavigation { get; set; }
        public virtual ICollection<Profile> ProfileGenderNavigation { get; set; }
        public virtual ICollection<Profile> ProfileProfileStatusNavigation { get; set; }
        public virtual ICollection<Profile> ProfileRoleNavigation { get; set; }
        public virtual ICollection<Profile> ProfileStateNavigation { get; set; }
        public virtual ICollection<Profileapprovalstatus> Profileapprovalstatus { get; set; }
        public virtual ICollection<Profilepermission> Profilepermission { get; set; }
        public virtual ICollection<Profilestatus> Profilestatus { get; set; }
        public virtual ICollection<Rolesettings> Rolesettings { get; set; }
    }
}
