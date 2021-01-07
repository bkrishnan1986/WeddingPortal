using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.LeadManagement.Core.DTO.Responses
{
    public class LeadValidationResponse
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public int CalledBy { get; set; }
        public DateTime CalledOn { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string Remark { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string CallRecordings { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
