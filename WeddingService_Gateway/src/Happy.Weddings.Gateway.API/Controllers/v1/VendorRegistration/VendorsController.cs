using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.VendorRegistration;
using Happy.Weddings.Gateway.Core.Services.v1.VendorRegistration;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.VendorRegistration
{
    /// <summary>
    /// Vendor operations handled by this controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("vendors")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        /// <summary>
        /// The vendor service
        /// </summary>
        private readonly IVendorService vendorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VendorsController"/> class.
        /// </summary>
        /// <param name="vendorService">The vendor service.</param>
        public VendorsController(
            IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }
        /// <summary>
        /// Add the Vendor Assets.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAssets([FromBody] CreateVendorRegistrationDetailsRequest request)
        {
            var result = await vendorService.CreateVendor(request);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
