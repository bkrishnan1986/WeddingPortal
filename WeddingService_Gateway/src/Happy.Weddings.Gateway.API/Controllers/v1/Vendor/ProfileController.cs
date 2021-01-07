using Happy.Weddings.Gateway.Core.DTO.Vendor.ProfilePicture;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendors Profile operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    //[Consumes("application/json")]
    [Route("api/v1/vendor/vendorprofile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// The branch service
        /// </summary>
        private readonly IProfileService profileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileController"/> class.
        /// </summary>
        /// <param name="profileService">The branch service.</param>
        public ProfileController(
            IProfileService profileService)
        {
            this.profileService = profileService;
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
            var result = await profileService.GetCategoryDetailsByVendorId(vendorId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Category Details.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("categoryDetails")]
        [HttpPost]
        public async Task<IActionResult> CreateCategoryDetails([FromForm]CreateCategoryDetailsRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.SubCategoryList))
            {
                var subCategories = JsonConvert.DeserializeObject<List<SubCategory>>(request.SubCategoryList);
                request.SubCategory = subCategories;
            }
            var result = await profileService.CreateCategoryDetails(request);
            return StatusCode((int)result.Code, result.Value);         
        }

        /// <summary>
        /// Updates Profile Picture.
        /// </summary>
        /// <param name="categoryId">The profilePicture identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{categoryId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryDetails(int categoryId, [FromForm] UpdateCategoryDetailsRequest request)
        {
            var result = await profileService.UpdateCategoryDetails(categoryId,request);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
