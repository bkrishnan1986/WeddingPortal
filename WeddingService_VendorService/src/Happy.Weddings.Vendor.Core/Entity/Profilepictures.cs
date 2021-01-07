using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Profilepictures
    {
        /// <summary>
        /// Gets or sets the profle picture identifier.
        /// </summary>
        /// <value>
        /// The profle picture identifier.
        /// </value>
        public int ProflePictureId { get; set; }
        /// <summary>
        /// Gets or sets the profile picture path.
        /// </summary>
        /// <value>
        /// The profile picture path.
        /// </value>
        public string ProfilePicturePath { get; set; }
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int CategoryId { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }

        public virtual Categorydetails Category { get; set; }
    }
}
