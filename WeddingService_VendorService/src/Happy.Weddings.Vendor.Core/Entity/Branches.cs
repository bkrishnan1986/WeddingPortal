using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Branches
    {
        public Branches()
        {
            Branchserviceoffered = new HashSet<Branchserviceoffered>();
        }

        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string ListingAddress { get; set; }
        public string BuildingName { get; set; }
        public string FlatPlotDoorNo { get; set; }
        public string Floor { get; set; }
        public string StreetName { get; set; }
        public string LocalityName { get; set; }
        public string Pincode { get; set; }
        public string Landmark { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public short? EstablishedYear { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail District { get; set; }
        public virtual ICollection<Branchserviceoffered> Branchserviceoffered { get; set; }
    }
}

