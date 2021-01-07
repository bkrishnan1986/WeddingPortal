using Happy.Weddings.Gateway.Core.DTO.Vendor.Branch;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Branches;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendor branch and services offered  operations handled by this controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />

    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/vendor/branches")]
    [ApiController]
    public class BranchServicesController : ControllerBase
    {
        /// <summary>
        /// The branch service
        /// </summary>
        private readonly IBranchService branchService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchServicesController"/> class.
        /// </summary>
        /// <param name="branchService">The branch service.</param>
        public BranchServicesController(
            IBranchService branchService)
        {
            this.branchService = branchService;
        }

        /// <summary>
        /// Gets the type of the branches.
        /// </summary>
        /// <param name="branchParameters">The branch type identifier.</param>
        /// <returns></returns>
        [HttpGet]
         public async Task<IActionResult> GetAllBranches([FromQuery] BranchParameters branchParameters)
         {
            var result = await branchService.GetAllBranches(branchParameters);
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
            var result = await branchService.CreateBranch(request);
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
            var result = await branchService.UpdateBranch(branchId, request);
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
            var result = await branchService.DeleteBranch(branchId);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
