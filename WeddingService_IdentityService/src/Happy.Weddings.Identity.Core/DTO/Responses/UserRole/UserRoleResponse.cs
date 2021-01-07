using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Core.DTO.Responses.UserRole
{
    public class UserRoleResponse
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public short? Add { get; set; }
        public short? Edit { get; set; }
        public short? Delete { get; set; }
        public short? View { get; set; }
        public short? Approve { get; set; }
        public short? Authorise { get; set; }
        public short? Reports { get; set; }
        public string Description { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
