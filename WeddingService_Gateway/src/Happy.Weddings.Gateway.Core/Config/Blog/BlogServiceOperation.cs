namespace Happy.Weddings.Gateway.Core.Config.Blog
{
    public class BlogServiceOperation
    {
        #region Base

        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/blog-management";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "BlogService";

        /// <summary>
        /// The get stories cache name
        /// </summary>
        public static string GetStoriesCacheName = "GetBlogCache()";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"/hc";

        #endregion
        #region MultiCode

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiCodes() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string GetMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiCode() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Updates the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string UpdateMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string DeleteMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        #endregion

        #region MultiDetail

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="multicodeId">The Multicode identifier.</param>
        /// <returns></returns>
        public static string GetMultiDetailsById(string multicodeId) => $"{baseUrl}/multidetails/{multicodeId}";

        /// <summary>
        /// Creates the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Updates the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string UpdateMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        /// <summary>
        /// Deletes the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string DeleteMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        #endregion

        #region Stories

        /// <summary>
        /// Gets the stories.
        /// </summary>
        /// <returns></returns>
        public static string GetStories() => $"{baseUrl}/stories";

        /// <summary>
        /// Gets the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        public static string GetStory(int storyId) => $"{baseUrl}/stories/{storyId}";

        /// <summary>
        /// Gets the TaggedData.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        public static string GetTaggedDataByStoryId(int storyId) => $"{baseUrl}/stories/{storyId}";

        /// <summary>
        /// Creates the story.
        /// </summary>
        /// <returns></returns>
        public static string CreateStory() => $"{baseUrl}/stories";

        /// <summary>
        /// Updates the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        public static string UpdateStory(int storyId) => $"{baseUrl}/stories/{storyId}";

        /// <summary>
        /// Deletes the story.
        /// </summary>
        /// <param name="storyId">The story identifier.</param>
        /// <returns></returns>
        public static string DeleteStory(int storyId) => $"{baseUrl}/stories/{storyId}";

        #endregion

        #region Review

        /// <summary>
        /// Gets the Review.
        /// </summary>
        /// <returns></returns>
        public static string GetReviews() => $"{baseUrl}/reviews";

        /// <summary>
        /// Gets the Review.
        /// </summary>
        /// <param name="reviewId">The Review identifier.</param>
        /// <returns></returns>
        public static string GetReview(int reviewId) => $"{baseUrl}/reviews/{reviewId}";

        /// <summary>
        /// Creates the Review.
        /// </summary>
        /// <returns></returns>
        public static string CreateReview() => $"{baseUrl}/reviews";

        /// <summary>
        /// Updates the Review.
        /// </summary>
        /// <param name="reviewId">The Review identifier.</param>
        /// <returns></returns>
        public static string UpdateReview(int reviewId) => $"{baseUrl}/reviews/{reviewId}";

        /// <summary>
        /// Deletes the Review.
        /// </summary>
        /// <param name="reviewId">The Review identifier.</param>
        /// <returns></returns>
        public static string DeleteReview(int reviewId) => $"{baseUrl}/reviews/{reviewId}";

        #endregion

        #region CommentReply

        /// <summary>
        /// Gets the CommentReply.
        /// </summary>
        /// <returns></returns>
        public static string GetCommentReplies() => $"{baseUrl}/commentreply";

        /// <summary>
        /// Gets the CommentReply.
        /// </summary>
        /// <param name="commentReplyId">The CommentReplyId identifier.</param>
        /// <returns></returns>
        public static string GetCommentReply(int commentReplyId) => $"{baseUrl}/commentreply/{commentReplyId}";

        /// <summary>
        /// Creates the CommentReply.
        /// </summary>
        /// <returns></returns>
        public static string CreateCommentReply() => $"{baseUrl}/commentreply";

        /// <summary>
        /// Updates the CommentReply.
        /// </summary>
        /// <param name="commentReplyId">The CommentReplyId identifier.</param>
        /// <returns></returns>
        public static string UpdateCommentReply(int commentReplyId) => $"{baseUrl}/commentreply/{commentReplyId}";

        /// <summary>
        /// Deletes the CommentReply.
        /// </summary>
        /// <param name="commentReplyId">The CommentReplyId identifier.</param>
        /// <returns></returns>
        public static string DeleteCommentReply(int commentReplyId) => $"{baseUrl}/commentreply/{commentReplyId}";

        #endregion

    }
}
