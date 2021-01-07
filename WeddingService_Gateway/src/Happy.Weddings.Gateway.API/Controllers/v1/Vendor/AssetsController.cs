using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Asset;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Vendor Assets operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("Assets")]
    [ApiController]
    public class AssetsController : Controller
    {
        /// <summary>
        /// The asset service
        /// </summary>
        private readonly IAssetService assetService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsController"/> class.
        /// </summary>
        /// <param name="assetService">The asset service.</param>
        public AssetsController(
            IAssetService assetService)
        {
            this.assetService = assetService;
        }
        /// <summary>
        /// Add the Vendor Assets.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAssets([FromBody] AddAssetRequest request)
        {
            var result = await assetService.AddAssets(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the Asset.
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{assetId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsset(int assetId, [FromBody] UpdateAssetRequest request)
        {
            var result = await assetService.UpdateAsset(assetId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Asset.
        /// </summary>
        /// <param name="assetId">The asset identifier.</param>
        /// <returns></returns>
        [Route("{assetId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsset(int assetId)
        {
            var result = await assetService.DeleteAsset(assetId);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Get the  Assets by Id.
        /// </summary>
        /// <param name="assetId">The Offer identifier.</param>
        /// <returns></returns>
        [Route("{assetId}")]
        [HttpGet]
        public async Task<IActionResult> GetAssetById(int assetId)
        {
            var result = await assetService.GetAssetById(assetId);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets all Assets
        /// </summary>
        /// <param name="assetParameters">The  Asset Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAssets([FromQuery] AssetParameters assetParameters)
        {
            var result = await assetService.GetAllAssets(assetParameters);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
