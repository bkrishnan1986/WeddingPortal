#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSubscriptionOfferHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionOffers;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.SubscriptionOffer
{
    /// <summary>
    /// Handler for updating a SubscriptionOffers
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.UpdateSubscriptionPlanCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateSubscriptionOfferHandler : IRequestHandler<UpdateSubscriptionOfferCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateSubscriptionBenefitHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateSubscriptionOfferHandler(
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
        public async Task<APIResponse> Handle(UpdateSubscriptionOfferCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var story = await repository.SubscriptionOffers.GetSubscriptionOfferById(request.SubscriptionOfferId);
                if (story == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                var storyRequest = mapper.Map(request.Request, story);
                repository.SubscriptionOffers.UpdateSubscriptionOffer(storyRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateSubscriptionOfferHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
