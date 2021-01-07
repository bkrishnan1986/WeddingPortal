﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  19-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | DeleteServiceSubscriptionHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceSubscriptions;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServiceSubscriptions
{
    /// <summary>
    /// Handler for deleting a ServiceSubscriptions
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.DeleteServiceSubscriptionCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteServiceSubscriptionHandler : IRequestHandler<DeleteServiceSubscriptionCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="DeleteSubscriptionPlanHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public DeleteServiceSubscriptionHandler(
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
        public async Task<APIResponse> Handle(DeleteServiceSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var serviceSubscriptions = await repository.ServiceSubscriptions.GetServiceSubscriptionById(request.ServiceSubscriptiontId);
                if (serviceSubscriptions == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
                serviceSubscriptions.Active = 0;
                repository.ServiceSubscriptions.UpdateServiceSubscription(serviceSubscriptions);
                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteVendorSubscriptionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
