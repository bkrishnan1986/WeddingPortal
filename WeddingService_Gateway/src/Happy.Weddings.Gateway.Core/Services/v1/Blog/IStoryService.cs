﻿using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Blog.Story;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Blog
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface IStoryService
    {
        /// <summary>
        /// Gets the stories.
        /// </summary>
        /// <param name="storyParametersRequest">The story parameters request.</param>
        /// <returns></returns>
        Task<APIResponse> GetStories(StoryParametersRequest storyParametersRequest);

        /// <summary>
        /// Gets the story.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetStory(StoryIdDetails details);

        /// <summary>
        /// Gets the TaggedData.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetTaggedDataByStoryId(StoryIdDetails details);

        /// <summary>
        /// Creates the story.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateStory(CreateStoryRequest request);

        /// <summary>
        /// Updates the story.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateStory(StoryIdDetails details, UpdateStoryRequest request);

        /// <summary>
        /// Deletes the story.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteStory(StoryIdDetails details);
    }
}
