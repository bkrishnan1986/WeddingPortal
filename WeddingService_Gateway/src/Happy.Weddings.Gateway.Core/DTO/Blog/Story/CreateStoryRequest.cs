using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Story
{
    public class CreateStoryRequest
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>
        /// The type of the event.
        /// </value>
        public int EventType { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the cover photo or video.
        /// </summary>
        /// <value>
        /// The cover photo or video.
        /// </value>
        public string CoverPhotoOrVideo { get; set; }

        /// <summary>
        /// Gets or sets the Blog identifier.
        /// </summary>
        /// <value>
        /// The Blog identifier.
        /// </value>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

        public List<TagData> TagList { get; set; }

        public IFormFile CoverPhotoVideo { get; set; }
    }
    public class TagData
    {
        /// <summary>
        /// Gets or sets the tag identifier.
        /// </summary>
        /// <value>
        /// The tag identifier.
        /// </value>
        public int TagId { get; set; }

        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        /// <value>
        /// The name of the tag.
        /// </value>
        public string TagName { get; set; }

    }
}
