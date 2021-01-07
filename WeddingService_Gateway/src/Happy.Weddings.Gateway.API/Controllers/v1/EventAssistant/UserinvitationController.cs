using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Userinvitation;
using Happy.Weddings.Gateway.Core.Services.v1.EventAssistant;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.EventAssistant
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/EventAssistant-management/userinvitations")]
    [ApiController]
    public class UserinvitationsController : Controller
    {

        private readonly IUserinvitationService userinvitationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserinvitationsController"/> class.
        /// </summary>
        /// <param name="userinvitationService">The userinvitation service.</param>
        public UserinvitationsController(
            IUserinvitationService userinvitationService)
        {
            this.userinvitationService = userinvitationService;
        }

        /// <summary>
        /// Gets the user invitations.
        /// </summary>
        /// <param name="userinvitationParameters">The userinvitation parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserInvitations([FromQuery] UserinvitationParameters userinvitationParameters)
        {
            var result = await userinvitationService.GetUserinvitations(userinvitationParameters);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets the userinvitation by identifier.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <returns></returns>
        [Route("{userinvitationId}")]
        [HttpGet]
        public async Task<IActionResult> GetUserinvitationById(int userinvitationId)
        {
            var result = await userinvitationService.GetUserinvitationById(userinvitationId);
            return StatusCode((int)result.Code, result.Value);
        }


        /// <summary>
        /// Creates the user invitations.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUserInvitations([FromBody] CreateUserInvitationListRequest request)
        {
            var result = await userinvitationService.CreateUserinvitations(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the user invitations.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{userinvitationId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserInvitations(int userinvitationId, [FromBody] UpdateUserinvitationRequest request)
        {
            var result = await userinvitationService.UpdateUserinvitations(userinvitationId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the user invitations.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <returns></returns>
        [Route("{userinvitationId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserInvitations(int userinvitationId)
        {
            var result = await userinvitationService.DeleteUserinvitations(userinvitationId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
