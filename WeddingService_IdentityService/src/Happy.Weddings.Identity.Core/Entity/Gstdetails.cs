using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Gstdetails
    {
        public int Id { get; set; }
        public int Kycid { get; set; }
        public string Gstnumber { get; set; }
        public int Gststate { get; set; }
        public int Gstcity { get; set; }
        public string Gstdocument { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail GstcityNavigation { get; set; }
        public virtual Multidetail GststateNavigation { get; set; }
        public virtual Kycdata Kyc { get; set; }
    }
}
