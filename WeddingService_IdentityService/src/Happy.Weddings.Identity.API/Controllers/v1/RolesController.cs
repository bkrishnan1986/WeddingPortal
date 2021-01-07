using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Domain;
using Happy.Weddings.Identity.Core.DTO.Requests.UserRole;
using Happy.Weddings.Identity.Service.Commands.v1.UserRole;
using Happy.Weddings.Identity.Service.Queries.v1.UserRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Happy.Weddings.Identity.API.Controllers.v1
{
    /// <summary>
    /// User roles Controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("roles")]
    [ApiController]
    public class RolesController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public RolesController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUserRole([FromBody] CreateUserRoleRequest request)
        {
            var createUserRoleCommand = new CreateUserRoleCommand(request);
            var result = await mediator.Send(createUserRoleCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the user role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{roleId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserRole(int roleId, [FromBody] UpdateUserRoleRequest request)
        {
            var updateUserRoleCommand = new UpdateUserRoleCommand(roleId, request);
            var result = await mediator.Send(updateUserRoleCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="roleParameters">The profile parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserRoles([FromQuery] UserRoleParameters roleParameters)
        {
            var getAllUserRolesQuery = new GetAllUserRolesQuery(roleParameters);
            var result = await mediator.Send(getAllUserRolesQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the user role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        [Route("{roleId}")]
        [HttpGet]
        public async Task<IActionResult> GetUserRole(int roleId)
        {
            var getUserRoleQuery = new GetUserRoleQuery(roleId);
            var result = await mediator.Send(getUserRoleQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the user role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        [Route("{roleId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserRole(int roleId)
        {
            var deleteUserRoleCommand = new DeleteUserRoleCommand(roleId);
            var result = await mediator.Send(deleteUserRoleCommand);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
