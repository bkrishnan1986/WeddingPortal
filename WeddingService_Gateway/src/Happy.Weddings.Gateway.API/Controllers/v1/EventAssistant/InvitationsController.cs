using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Invitation;
using Happy.Weddings.Gateway.Core.Services.v1.EventAssistant;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.EventAssistant
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/EventAssistant-management/invitations")]
    [ApiController]
    public class InvitationsController : Controller
    {
     
        private readonly IInvitationService invitationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationsController"/> class.
        /// </summary>
        /// <param name="invitationService">The invitation service.</param>
        public InvitationsController(
            IInvitationService invitationService)
        {
            this.invitationService = invitationService;
        }
        /// <summary>
        /// Gets the invitations.
        /// </summary>
        /// <param name="guestlistParameters">The guestlist parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetInvitations([FromQuery] InvitationParameters guestlistParameters)
        {
            var result = await invitationService.GetInvitations(guestlistParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the invitation by identifier.
        /// </summary>
        /// <param name="invitationId">The invitation identifier.</param>
        /// <returns></returns>
        [Route("{invitationId}")]
        [HttpGet]
        public async Task<IActionResult> GetInvitationById(int invitationId)
        {
            var result = await invitationService.GetInvitationById(invitationId);
            return StatusCode((int)result.Code, result.Value);
        }


        /// <summary>
        /// Creates the invitations.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateInvitations([FromBody] CreateInvitationRequest request)
        {
            var result = await invitationService.CreateInvitations(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the invitations.
        /// </summary>
        /// <param name="invitationId">The invitation identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{invitationId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateInvitations(int invitationId, [FromBody] UpdateInvitationRequest request)
        {
            var result = await invitationService.UpdateInvitations(invitationId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the invitations.
        /// </summary>
        /// <param name="invitationId">The invitation identifier.</param>
        /// <returns></returns>
        [Route("{invitationId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteInvitations(int invitationId)
        {
            var result = await invitationService.DeleteInvitations(invitationId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
