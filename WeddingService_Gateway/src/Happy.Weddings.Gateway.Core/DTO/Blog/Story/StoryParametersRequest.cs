using System;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Story
{
    public class StoryParametersRequest : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoryParametersRequest"/> class.
        /// </summary>
        public StoryParametersRequest()
        {
            //OrderBy = "Title";
        }
        public int Value { get; set; }
        public bool IsStoryForPendingApproval { get; set; }
        public bool IsStoryForParticularService { get; set; }
        public bool IsStoryForParticularVendor { get; set; }
        public bool IsForSingleStory { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
