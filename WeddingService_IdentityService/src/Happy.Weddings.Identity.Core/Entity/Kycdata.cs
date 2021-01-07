using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Kycdata
    {
        public Kycdata()
        {
            Gstdetails = new HashSet<Gstdetails>();
            Kycdetails = new HashSet<Kycdetails>();
        }

        public int Id { get; set; }
        public int Kycid { get; set; }
        public int VendorId { get; set; }
        public int Kycstatus { get; set; }
        public string FatherName { get; set; }
        public DateTime? Dob { get; set; }
        public string DocumentId { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail Kyc { get; set; }
        public virtual Multidetail KycstatusNavigation { get; set; }
        public virtual Profile Vendor { get; set; }
        public virtual ICollection<Gstdetails> Gstdetails { get; set; }
        public virtual ICollection<Kycdetails> Kycdetails { get; set; }
    }
}
