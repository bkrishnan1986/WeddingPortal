using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Branch;
using Happy.Weddings.Vendor.Core.DTO.Requests.Branches;
using Happy.Weddings.Vendor.Service.Commands.v1.Branch;
using Happy.Weddings.Vendor.Service.Queries.v1.Branch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendor branch and services offered  operations handled by this controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />

    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("branch")]
    [ApiController]
    public class BranchServicesController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceQuestionController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public BranchServicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the type of the branches.
        /// </summary>
        /// <param name="branchParameters">The branch type identifier.</param>
        /// <returns></returns>
        [HttpGet]
         public async Task<IActionResult> GetAllBranches([FromQuery] BranchParameters branchParameters)
         {
              var getAllBranchQuery = new GetAllBranchesQuery(branchParameters);
              var result = await mediator.Send(getAllBranchQuery);

             /* if (result.Code == HttpStatusCode.OK)
              {
                  Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
              }        */

              return StatusCode((int)result.Code, result.Value);
         }

        /// <summary>
        /// Creates the Branch.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
       // [Route("createbranch")]
        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request)
        {
            var createBranchCommand = new CreateBranchCommand(request);
            var result = await mediator.Send(createBranchCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the branch.
        /// </summary>
        /// <param name="branchId">The branch identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{branchId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateBranch(int branchId, [FromBody] UpdateBranchRequest request)
        {
            var updatebranchCommand = new UpdateBranchCommand(branchId, request);
            var result = await mediator.Send(updatebranchCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the branch.
        /// </summary>
        /// <param name="branchId">The district  identifier.</param>
        /// <returns></returns>
        [Route("{branchId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(int branchId)
        {
            var deleteBranchCommand = new DeleteBranchCommand(branchId);
            var result = await mediator.Send(deleteBranchCommand);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
