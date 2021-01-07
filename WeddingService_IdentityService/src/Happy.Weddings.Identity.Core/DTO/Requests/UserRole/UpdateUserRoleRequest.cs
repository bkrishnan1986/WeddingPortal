using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Core.DTO.Requests.UserRole
{
    public class UpdateUserRoleRequest
    {
        public int RoleId { get; set; }
        public string RolePermissions { get; set; }
        public string Description { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
