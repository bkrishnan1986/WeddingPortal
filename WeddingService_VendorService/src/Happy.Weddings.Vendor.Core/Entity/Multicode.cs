using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    /// <summary>
    ///  This class is used to map MultiCode Entity
    /// </summary>
    public partial class Multicode
    {
        public Multicode()
        {
            Multidetail = new HashSet<Multidetail>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string SystemCode { get; set; }
        public string Description { get; set; }
        public short? IsRequired { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Multidetail> Multidetail { get; set; }
    }
}
