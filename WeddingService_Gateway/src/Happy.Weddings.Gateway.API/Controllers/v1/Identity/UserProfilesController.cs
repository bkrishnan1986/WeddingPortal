using System.Collections.Generic;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.DTO.Identity.Profile;
using Happy.Weddings.Gateway.Core.Services.v1.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Identity
{
    /// <summary>
    /// Identity users operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    // [Consumes("application/json")]
    [Route("api/v1/profiles")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        /// <summary>
        /// The story service
        /// </summary>
        private readonly IUserProfileService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfilesController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserProfilesController(
            IUserProfileService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserProfiles([FromQuery] UserProfileParameters profileParameters)
        {
            var result = await userService.GetUserProfiles(profileParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="profileId">The user identifier.</param>
        /// <returns></returns>
        [Route("{profileId}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile(int profileId)
        {
            var result = await userService.GetUserProfile(new ProfileIdDetails(profileId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        // [Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserProfileRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.CompanyDistrictsString))
            {
                var companyDistricts = JsonConvert.DeserializeObject<List<CompanyDistricts>>(request.CompanyDistrictsString);
                request.CompanyDistricts = companyDistricts;
            }
            if (!string.IsNullOrWhiteSpace(request.ProfilePermissionString))
            {
                var permissions = JsonConvert.DeserializeObject<ProfilePermission>(request.ProfilePermissionString);
                request.ProfilePermission = new List<ProfilePermission>() { permissions };
            }
            var result = await userService.CreateUserProfile(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="profileId">The user identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{profileId}")]
        [HttpPut]
        [Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateUserProfile(int profileId, [FromForm] UpdateUserProfileRequest request)
        {
            var result = await userService.UpdateUserProfile(new ProfileIdDetails(profileId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="profileId">The user identifier.</param>
        /// <returns></returns>
        [Route("{profileId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserProfile(int profileId)
        {
            var result = await userService.DeleteUserProfile(new ProfileIdDetails(profileId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get UserId
        /// </summary>
        /// <param name="idParameters"></param>
        /// <returns></returns>
        [Route("userId")]
        [HttpGet]
        public async Task<IActionResult> GetUserId([FromQuery] UserIdParameters idParameters)
        {
            var result = await userService.GetUserId(idParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// SendOtp
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("{profileId}/otpSend")]
        [HttpPost]
        public async Task<IActionResult> SendOtp(int profileId, [FromBody] SendOtpRequest request)
        {
            var result = await userService.SendOtp(new ProfileIdDetails(profileId),request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// VerifyOtp
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("{profileId}/otpVerify")]
        [HttpPost]
        public async Task<IActionResult> VerifyOtp(int profileId, [FromBody] VerifyOtpRequest request)
        {
            var result = await userService.VerifyOtp(new ProfileIdDetails(profileId),request);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
