using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    /// <summary>
    /// This class is used to map Events Entity 
    /// </summary>
    public partial class Events
    {
        public Events()
        {
            Eventphoto = new HashSet<Eventphoto>();
            Gallery = new HashSet<Gallery>();
            Eventtagdata = new HashSet<Eventtagdata>();
        }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>
        /// The type of the event.
        /// </value>
        public int EventType { get; set; }
        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        /// <value>
        /// The name of the event.
        /// </value>
        public string EventName { get; set; }
        /// <summary>
        /// Gets or sets the cover photo.
        /// </summary>
        /// <value>
        /// The cover photo.
        /// </value>
        public string CoverPhoto { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        public DateTime EventDate { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public string Tags { get; set; }
        /// <summary>
        /// Gets or sets the estimated price.
        /// </summary>
        /// <value>
        /// The estimated price.
        /// </value>
        public decimal? EstimatedPrice { get; set; }
        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short Active { get; set; }
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

        public virtual Multidetail ApprovalStatusNavigation { get; set; }
        public virtual Multidetail EventTypeNavigation { get; set; }
        public virtual ICollection<Eventtagdata> Eventtagdata { get; set; }
        public virtual ICollection<Eventphoto> Eventphoto { get; set; }
        public virtual ICollection<Gallery> Gallery { get; set; }
    }
}
