#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllServiceTopupHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceTopup;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServiceTopups
{
    /// <summary>
    /// Handler for getting all ServiceTopups
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Queries.GetAllSubscriptionPlansQuery, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class GetAllServiceTopupHandler : IRequestHandler<GetAllServiceTopupQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetAllSubscriptionPlansHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllServiceTopupHandler(
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
        public async Task<APIResponse> Handle(GetAllServiceTopupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var subscriptions = await repository.ServiceTopups.GetAllServiceTopups(request.ServiceTopupParameter);
                return new APIResponse(subscriptions, HttpStatusCode.OK);
                //  return null;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllSubscriptionPlansHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
