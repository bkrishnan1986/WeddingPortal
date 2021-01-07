#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | AssetController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Asset;
using Happy.Weddings.Vendor.Service.Commands.v1.Asset;
using Happy.Weddings.Vendor.Service.Queries.v1.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Vendor.API.Controllers.v1
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
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public AssetsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Add the Vendor Assets.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAssets([FromBody] AddAssetRequest request)
        {
            var createServiceCommand = new CreateAssetCommand(request);
            var result = await mediator.Send(createServiceCommand);
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
            var updateServiceCommand = new UpdateAssetCommand(assetId, request);
            var result = await mediator.Send(updateServiceCommand);
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
            var deleteServiceCommand = new DeleteAssetCommand(assetId);
            var result = await mediator.Send(deleteServiceCommand);
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
            var getAssetQuery = new GetAssetQuery(assetId);
            var result = await mediator.Send(getAssetQuery);
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
            var getAllBenefitsQuery = new GetAllAssetsQuery(assetParameters);
            var result = await mediator.Send(getAllBenefitsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }
    }
}