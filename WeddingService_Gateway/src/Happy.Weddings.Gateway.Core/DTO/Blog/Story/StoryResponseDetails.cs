using Happy.Weddings.Gateway.Core.Domain.Blog;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Story
{
    public class StoryResponseDetails : StoryResponse
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Commentreply> Comments { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Taggeddata> TaggedData { get; set; }
    }
}
