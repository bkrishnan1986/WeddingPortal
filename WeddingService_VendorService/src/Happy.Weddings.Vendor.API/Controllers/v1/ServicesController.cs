#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | ServiceController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses.Service;
using Happy.Weddings.Vendor.Service.Commands.v1.Service;
using Happy.Weddings.Vendor.Service.Queries.v1.Service;
using Happy.Weddings.Vendor.Service.Queries.v1.ServicesOffered;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendor Services operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("services")]
    [ApiController]
    public class ServicesController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ServicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Add the Vendor Services.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] List<AddServicesRequest> request)
        {
            try
            {
                foreach (var item in request)
                {
                    var createServiceCommand = new CreateServiceCommand(item);
                    var result = await mediator.Send(createServiceCommand);
                }

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

            return StatusCode(201);
        }

        /// <summary>
        /// Updates the service.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{serviceId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateService(int serviceId, [FromBody] UpdateServiceRequest request)
        {
            var updateServiceCommand = new UpdateServiceCommand(serviceId, request);
            var result = await mediator.Send(updateServiceCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns></returns>
        [Route("{serviceId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            var deleteServiceCommand = new DeleteServiceCommand(serviceId);
            var result = await mediator.Send(deleteServiceCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="serviceParameters">The service parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllServices([FromQuery] ServicesParameters serviceParameters)
        {
            var getAllServicesQuery = new GetAllServicesQuery(serviceParameters);
            var result = await mediator.Send(getAllServicesQuery);

            //if (result.Code == HttpStatusCode.OK)
            //{
            //    Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            //}

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        ///Search the Services.
        /// </summary>
        /// <param name="searchParameters">The search services parameters.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchServices")]

        public async Task<IActionResult> SearchServices([FromQuery] SearchParameters searchParameters)
        {
            var getAllServicesQuery = new SearchFromAllServicesQuery(searchParameters);
            var result = await mediator.Send(getAllServicesQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }


        /// <summary>
        /// Gets the services of vendor.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        [Route("vendorservice/{vendorId}")]
        [HttpGet]
        public async Task<IActionResult> GetServicesofVendor(string vendorId)
        {
            var GetServicesofVendorQuery = new GetServicesofVendorQuery(vendorId);
            var result = await mediator.Send(GetServicesofVendorQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the service offered by service identifier.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns></returns>
        [Route("{serviceId}")]
        [HttpGet]
        public async Task<IActionResult> GetServiceOfferedByServiceId(int serviceId)
        {
            var getServicesOfferedByServiceIdQuery = new GetServicesOfferedByServiceIdQuery(serviceId);
            var result = await mediator.Send(getServicesOfferedByServiceIdQuery);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}