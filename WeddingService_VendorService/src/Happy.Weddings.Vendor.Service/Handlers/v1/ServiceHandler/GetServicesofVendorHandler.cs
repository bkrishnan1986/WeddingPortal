#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | GetServicesofVendorHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.DTO.Responses.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.Service;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServiceHandler
{
    /// <summary>
    /// Handler for getting all services of Vendor
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Blog.Service.v1.Queries.GetAllServicesQuery, Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class GetServicesofVendorHandler : IRequestHandler<GetServicesofVendorQuery, APIResponse>
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
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetServicesofVendorHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetServicesofVendorHandler(
            IRepositoryWrapper repository,
             IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(GetServicesofVendorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var services = await repository.ServiceRepository.GetServicesofVendor(request.VendorId);
                if (services == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
                
                foreach (var item in services)
                {                    
                    var subscriptionList = item.Servicesubscription;

                    foreach(var items in subscriptionList)
                    {
                        var subscriptionId = items.Subscription;
                        var subscriptionLocationList = await repository.SubscriptionLocations.GetSubscriptions(subscriptionId);
                        item.SubscriptionLocation = subscriptionLocationList;

                        var subscriptionPlanList = await repository.SubscriptionPlans.GetSubscriptionPlans(subscriptionId);
                        item.SubscriptionPlan = subscriptionPlanList;

                        foreach (var subscriptions in subscriptionPlanList)
                        {
                            var subcriptionbenefitId = subscriptions.Id;

                            var subscriptionbenefitsList = await repository.SubscriptionBenefits.GetSubscriptionBenefitsById(subcriptionbenefitId);
                            item.Subscriptionbenefit = subscriptionbenefitsList;
                        }
                    }
                   
                    var serviceTopUpList = await repository.ServiceTopups.GetServiceTopups(item.Id);
                    item.Servicetopup = serviceTopUpList;
                    foreach(var topups in serviceTopUpList)
                    {
                        var topupId = topups.TopUpId;
                        var topupList = await repository.TopUps.GetTopUpsById(topupId);
                        item.TopUp = topupList;      
                       
                        foreach (var topUpBenefits in topupList)
                        {
                            var topupBenefitId = topUpBenefits.Id;
                            var topupBenefitList = await repository.TopUpBenefits.GetTopUpBenefitsById(topupBenefitId);
                            item.Topupbenefit = topupBenefitList;
                        }
                    }
                }

                return new APIResponse(services, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetServicesofVendorHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
