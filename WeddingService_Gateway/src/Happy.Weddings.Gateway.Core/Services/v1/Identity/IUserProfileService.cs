using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.DTO.Identity.Profile;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Identity
{
    /// <summary>
    /// Service interface for user related operations
    /// </summary>
    public interface IUserProfileService
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        Task<APIResponse> GetUserProfiles(UserProfileParameters profileParameters);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetUserProfile(ProfileIdDetails details);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateUserProfile(CreateUserProfileRequest request);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateUserProfile(ProfileIdDetails details, UpdateUserProfileRequest request);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteUserProfile(ProfileIdDetails details);

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="idParameters">The identifier parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetUserId(UserIdParameters idParameters);

        /// <summary>
        /// Verifies the otp.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> VerifyOtp(ProfileIdDetails details, VerifyOtpRequest request);

        /// <summary>
        /// Sends the otp.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> SendOtp(ProfileIdDetails details,SendOtpRequest request);
    }
}
