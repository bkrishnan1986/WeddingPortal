using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply
{
    public class CommentReplyResponseDetails
    {
        /// <summary>
        /// Gets or sets the Review.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Blog.Commentreply> CommentReply { get; set; }
    }
}
