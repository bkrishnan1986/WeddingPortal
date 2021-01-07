#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateTopUpHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
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
    /// Handler for creating a TopUp
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.CreateVendorSubscriptioncommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateTopUpHandler : IRequestHandler<CreateTopUpcommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateStoryHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateTopUpHandler(
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
        public async Task<APIResponse> Handle(CreateTopUpcommand request, CancellationToken cancellationToken)
        {
            try
            {
                var topupRequest = mapper.Map<Topup>(request.Request);
                var totPrice = topupRequest.Price;
               /* topupRequest.TotalPrice = (totPrice + (totPrice * (topupRequest.Gstpercentage) / 100));
                topupRequest.TotalPrice = (topupRequest.Price + (topupRequest.Price * (topupRequest.Gstpercentage) / 100));         */
                repository.TopUps.CreateTopUp(topupRequest);
                await repository.SaveAsync();
                return new APIResponse(topupRequest, HttpStatusCode.Created);
                // return null;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateVendorSubscriptionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
