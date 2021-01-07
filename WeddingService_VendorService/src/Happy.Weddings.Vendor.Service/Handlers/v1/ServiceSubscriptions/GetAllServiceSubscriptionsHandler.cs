#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllVendorSubscriptionsHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceSubscriptions;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServiceSubscriptions
{
    /// <summary>
    /// Handler for getting all VendorSubscriptions
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Queries.GetAllVendorSubscriptionsQuery, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class GetAllServiceSubscriptionsHandler : IRequestHandler<GetAllServiceSubscriptionsQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetAllServiceSubscriptionsHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllServiceSubscriptionsHandler(
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
        public async Task<APIResponse> Handle(GetAllServiceSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var servicesubscriptions = await repository.ServiceSubscriptions.GetAllServiceSubscriptions(request.ServiceSubscriptionsParameter);
                return new APIResponse(servicesubscriptions, HttpStatusCode.OK);
                //  return null;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllVendorSubscriptionsHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
