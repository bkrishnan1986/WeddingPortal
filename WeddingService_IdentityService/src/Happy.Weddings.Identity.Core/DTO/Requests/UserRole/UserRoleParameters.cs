using Happy.Weddings.Identity.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Core.DTO.Requests.UserRole
{
    public class UserRoleParameters:QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleParameters"/> class.
        /// </summary>
        public UserRoleParameters()
        {
            OrderBy = "Title";
        }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        public string SearchKeyword { get; set; }

        /// <summary>
        /// Gets or sets the value keyword.
        /// </summary>
        public string Value { get; set; }
    }
}
