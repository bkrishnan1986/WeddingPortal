#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | AccountsController class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Identity.Core.DTO.Requests.Account;
using Happy.Weddings.Identity.Service.Commands.v1.Account;
using Happy.Weddings.Identity.Service.Queries.v1.Account;
using Happy.Weddings.Identity.Core.Services.Providers;

#endregion

namespace Happy.Weddings.Identity.API.Controllers.v1
{
    /// <summary>
    /// AccountsController
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("Accounts")]
    [ApiController]
    public class AccountsController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public AccountsController(
            IMediator mediator)
        {
            this.mediator = mediator;;
        }

        /// <summary>
        /// Get Login details.
        /// </summary>
        /// <param name="loginParameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAccountsDetails([FromQuery] AccountParameters loginParameters)
        {
            var getAccountDetailsQuery = new GetAccountDetailsQuery(loginParameters);
            var result = await mediator.Send(getAccountDetailsQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates account portion values.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> UpdateAccountsPortion([FromBody] UpdateAccountsPortionRequest request)
        {
            var updateAccountPortionCommand = new UpdateAccountPortionCommand(request);
            var result = await mediator.Send(updateAccountPortionCommand);
            return StatusCode((int)result.Code, result.Value);
        }
        
        /*
        /// <summary>
        /// Gets the Profile.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <returns></returns>
        [Route("{userName}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile(string userName)
        {
            var getUserProfileQuery = new GetUserProfileQuery(profileId);
            var result = await mediator.Send(getUserProfileQuery);
            return StatusCode((int)result.Code, result.Value);
        }
        */

    }
}
