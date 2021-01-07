#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | RoleOutResponse class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Responses.Role
{
    public class RoleOutResponse
    {
        /// <summary>
        /// Gets or sets role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets module id.
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// Gets or sets submodule id.
        /// </summary>
        public int SubmoduleId { get; set; }

        /// <summary>
        /// Gets or sets add permission.
        /// </summary>
        public short? Add { get; set; }

        /// <summary>
        /// Gets or sets edit permission.
        /// </summary>
        public short? Edit { get; set; }

        /// <summary>
        /// Gets or sets delete permission.
        /// </summary>
        public short? Delete { get; set; }

        /// <summary>
        /// Gets or sets view permission.
        /// </summary>
        public short? View { get; set; }

        /// <summary>
        /// Gets or sets export permission.
        /// </summary>
        public short? Export { get; set; }

        /// <summary>
        /// Gets or sets import permission.
        /// </summary>
        public short? Import { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets active.
        /// </summary>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets created by.
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets created date.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets updated by.
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets  updated date.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
