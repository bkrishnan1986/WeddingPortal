﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetSubscriptionLocationHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionLocation;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.SubscriptionLocation
{
    /// <summary>
    /// Handler for getting a SubscriptionLocation
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Queries.GetSubscriptionOfferQuery, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class GetSubscriptionLocationHandler : IRequestHandler<GetSubscriptionLocationQuery, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionPlanHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetSubscriptionLocationHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(GetSubscriptionLocationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var story = await repository.SubscriptionLocations.GetSubscriptionLocationsById(request.LocationParameters);
                if (story == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                return new APIResponse(story, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetSubscriptionLocationHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}

