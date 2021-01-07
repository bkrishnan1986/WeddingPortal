using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement
{
    public class CreateLeadValidationRequest
    {
        public int LeadId { get; set; }
        public int CalledBy { get; set; }
        public DateTime CalledOn { get; set; }
        public int Status { get; set; }
        public string Remark { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public IFormFile CallRecordingFile { get; set; }
        public string CallRecordings { get; set; }
        public int CreatedBy { get; set; }
    }
}
