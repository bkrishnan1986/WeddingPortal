#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | ProfileController class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Service.Commands.v1.Profile;
using Happy.Weddings.Identity.Service.Queries.v1.Profile;
using System.Net;
using Happy.Weddings.Identity.Core.Domain;

#endregion

namespace Happy.Weddings.Identity.API.Controllers.v1
{

    /// <summary>
    /// UserProfilesController
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("profiles")]
    [ApiController]
    public class UserProfilesController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public UserProfilesController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Creates the user profile.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserProfileRequest request)
        {
            var createUserProfileCommand = new CreateUserProfileCommand(request);
            var result = await mediator.Send(createUserProfileCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the profile.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{profileId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProfile(int profileId, [FromBody] UpdateUserProfileRequest request)
        {
            var updateUserProfileCommand = new UpdateUserProfileCommand(profileId, request);
            var result = await mediator.Send(updateUserProfileCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the profile.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{profileId}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateUserProfilePortion(int profileId, [FromBody] UpdateUserProfilePortionRequest request)
        {
            var updateUserProfilePortionCommand = new UpdateUserProfilePortionCommand(profileId, request);
            var result = await mediator.Send(updateUserProfilePortionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the profiles.
        /// </summary>
        /// <param name="profileParameters">The profile parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProfiles([FromQuery] UserProfileParameters profileParameters)
        {
            var getAllUserProfilesQuery = new GetAllUserProfilesQuery(profileParameters);
            var result = await mediator.Send(getAllUserProfilesQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        [Route("{profileId}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile(int profileId)
        {
            var getUserProfileQuery = new GetUserProfileQuery(profileId);
            var result = await mediator.Send(getUserProfileQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the profile.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        [Route("{profileId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserProfile(int profileId)
        {
            var deleteUserProfileCommand = new DeleteUserProfileCommand(profileId);
            var result = await mediator.Send(deleteUserProfileCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="idParameters">The identifier parameters.</param>
        /// <returns></returns>
        [Route("userId")]
        [HttpGet]
        public async Task<IActionResult> GetUserId([FromQuery]UserIdParameters idParameters)
        {
            var getUserIdQuery = new GetUserIdQuery(idParameters);
            var result = await mediator.Send(getUserIdQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Sends the otp.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{profileId}/otpSend")]
        [HttpPost]
        public async Task<IActionResult> SendOtp(int profileId,[FromBody] SendOtpRequest request)
        {
            var sendOtpCommand = new SendOtpCommand(profileId,request);
            var result = await mediator.Send(sendOtpCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Verifies the otp.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{profileId}/otpVerify")]
        [HttpPost]
        public async Task<IActionResult> VerifyOtp(int profileId,[FromBody] VerifyOtpRequest request)
        {
            var verifyOtpCommand = new VerifyOtpCommand(profileId,request);
            var result = await mediator.Send(verifyOtpCommand);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
