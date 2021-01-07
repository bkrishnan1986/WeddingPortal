using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Service.Commands.v1.ProfilePicture;
using Happy.Weddings.Vendor.Service.Queries.v1.ProfilePicture;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendors Profile operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("vendorprofile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ProfileController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the Category details by Vendor Id.
        /// </summary>
        /// <param name="vendorId">The vendor id.</param>
        /// <returns></returns>
        [Route("{vendorId}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryDetailsByVendorId(string vendorId)
        {
            var getCategoryDetailsQuery = new GetCategoryDetailsVendorIdQuery(vendorId);
            var result = await mediator.Send(getCategoryDetailsQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Category Details.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("categoryDetails")]
        [HttpPost]
        public async Task<IActionResult> CreateCategoryDetails([FromBody] CreateCategoryDetailsRequest request)
        {
            var createCategoryDetailsCommand = new CreateCategoryDetailsCommand(request);
            var result = await mediator.Send(createCategoryDetailsCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the Category Details.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{categoryId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryDetails(int categoryId, [FromBody] UpdateCategoryDetailsRequest request)
        {
            var updateCategoryDetailsCommand = new UpdateCategoryDetailsCommand(categoryId, request);
            var result = await mediator.Send(updateCategoryDetailsCommand);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
