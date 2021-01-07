#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  19-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateTopUpBenefitHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.TopUpBenefit;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.TopUpBenefits
{
    /// <summary>
    /// Handler for creating a TopUpBenefits
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.CreateVendorSubscriptioncommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateTopUpBenefitHandler : IRequestHandler<CreateTopUpBenefitCommand, APIResponse>
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
        public CreateTopUpBenefitHandler(
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
        public async Task<APIResponse> Handle(CreateTopUpBenefitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vendorSubscriptionRequest = mapper.Map<Topupbenefit>(request.Request);
                repository.TopUpBenefits.CreateTopUpBenefit(vendorSubscriptionRequest);

                await repository.SaveAsync();

                return new APIResponse(vendorSubscriptionRequest, HttpStatusCode.Created);
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
