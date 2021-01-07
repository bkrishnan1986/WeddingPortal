#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateSubscriptionPlanHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionPlans;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.SubscriptionPlan
{
    /// <summary>
    /// Handler for creating a SubscriptionPlan
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.CreateSubscriptionPlanCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateSubscriptionPlanHandler : IRequestHandler<CreateSubscriptionPlanCommand, APIResponse>
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
        public CreateSubscriptionPlanHandler(
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
        public async Task<APIResponse> Handle(CreateSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subscriptionRequest = mapper.Map<Subscription>(request.Request);
                var totPrice = subscriptionRequest.RegistrationFee + subscriptionRequest.ServiceFee;
                subscriptionRequest.TotalPrice =  (totPrice + (totPrice * (subscriptionRequest.IgstRatePercentage) / 100))??0;
                if(subscriptionRequest.ParentsubscriptionId == 0)
                {
                    subscriptionRequest.ParentsubscriptionId = null;
                }
            
                repository.SubscriptionPlans.CreateSubscriptionPlan(subscriptionRequest);

                //var benefitsRequest = mapper.Map<Subscriptionbenefit>(request.Request1);
                //repository.SubscriptionBenefits.CreateSubscriptionBenefit(benefitsRequest);

                await repository.SaveAsync();  

                return new APIResponse(subscriptionRequest, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateSubscriptionPlanHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
