using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail
{
    public class GstDetailsDTO
    {
        public int Id { get; set; }
        public int Kycid { get; set; }
        public string Gstnumber { get; set; }
        public int Gststate { get; set; }
        public string GststateName { get; set; }
        public int Gstcity { get; set; }
        public string GstcityName { get; set; }
        public string Gstdocument { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
