﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateTopUpHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.TopUp;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.TopUp
{
    /// <summary>
    /// Handler for updating a VendorSubscription
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.UpdateVendorSubscriptionCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateTopUpHandler : IRequestHandler<UpdateTopUpCommand, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTopUpHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateTopUpHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
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
        public async Task<APIResponse> Handle(UpdateTopUpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vendorSubscription = await repository.TopUps.GetTopUpById(request.TopupId);
                if (vendorSubscription == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                var vendorSubscriptionRequest = mapper.Map(request.Request, vendorSubscription);
                repository.TopUps.UpdateTopUp(vendorSubscriptionRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateVendorSubscriptionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
