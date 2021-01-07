#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  19-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateServiceSubscriptionHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceTopup;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.DTO.Requests.TopUpBenefit;
using Happy.Weddings.Vendor.Core.DTO.Requests.Utility;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceSubscriptions;
using Happy.Weddings.Vendor.Service.Commands.v1.Utility;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.Utility
{
    /// <summary>
    /// Handler for creating a ServiceSubscriptions
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.CreateServiceSubscriptioncommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateUtilityHandler : IRequestHandler<CreateUtilityCommand, APIResponse>
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
        public CreateUtilityHandler(
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
        public async Task<APIResponse> Handle(CreateUtilityCommand request, CancellationToken cancellationToken)
          {
            try
            {
                if(request.Request.ServiceTopupId == 0)
                {
                    request.Request.ServiceTopupId = null;
                }
                if (request.Request.ServiceSubscriptionId == 0)
                {
                    request.Request.ServiceSubscriptionId = null;
                }

                var subscriptionBenefitsParameter = new SubscriptionBenefitsParameter();
                var utilityRequest = new Vendorserviceutilisation();
                var topUpBenefitParameter = new TopUpBenefitParameter();
                List<TopUpBenefitResponse> topupBenefit = new List<TopUpBenefitResponse>();
                List<SubscriptionBenefitsResponse> subscriptionBenefit = new List<SubscriptionBenefitsResponse>();

                var subscriptionUtilityParameters = new SubscriptionUtilityParameters();
                subscriptionUtilityParameters.VendorId = request.Request.VendorId;
                subscriptionUtilityParameters.ServiceSubscriptionId = request.Request.ServiceSubscriptionId;
                subscriptionUtilityParameters.TopupId = request.Request.ServiceTopupId;
                subscriptionUtilityParameters.BenefitId = request.Request.Benefit;
        
                var utility = await repository.Utilitys.GetAllUtility(subscriptionUtilityParameters);
                var serviceSubscription = await repository.ServiceSubscriptions.GetServiceSubscriptionById(request.Request.ServiceSubscriptionId??0);
                var serviceTopup = await repository.ServiceTopups.GetServiceTopupById(request.Request.ServiceTopupId??0);
                var multidetail = await repository.MultiDetails.GetMultiDetailsById("PhotoCount");

                if (serviceSubscription != null)
                {
                    subscriptionBenefitsParameter.Value = serviceSubscription.Subscription;
                    subscriptionBenefit = await repository.SubscriptionBenefits.GetAllSubscriptionBenefitsBySubsId(subscriptionBenefitsParameter);
                }
                if (serviceTopup != null)
                {
                    topUpBenefitParameter.Value = serviceTopup.TopUpId;
                    topupBenefit = await repository.TopUpBenefits.GetAllTopUpBenefitsByTopupId(topUpBenefitParameter);
                }
                int? BenefitCount = 0;
                int? topupCount = 0;
                foreach (var item in subscriptionBenefit)
                {
                    if (item.Benefit == request.Request.Benefit)
                    {
                        BenefitCount += item.Count;
                    }
                }
                foreach (var item in topupBenefit)
                {
                    if (item.Benefit == request.Request.Benefit)
                    {
                        topupCount += item.Count;
                    }
                }
                if (BenefitCount >= request.Request.UtilityCount)
                {
                   foreach (var item1 in utility)
                   {
                       if (item1.VendorId == request.Request.VendorId &&
                           item1.ServiceSubscriptionId == request.Request.ServiceSubscriptionId &&
                           item1.Benefit == request.Request.Benefit)
                       {
                           var vendorSubscription = await repository.Utilitys.GetUtilityById(item1.Id);
                            vendorSubscription.UtilityCount = request.Request.UtilityCount;
                           if (vendorSubscription == null)
                           {
                               return new APIResponse(HttpStatusCode.NotFound);
                           }
                           utilityRequest = mapper.Map(request.Request, vendorSubscription);
                           repository.Utilitys.UpdateUtility(utilityRequest);
                           await repository.SaveAsync();
                       }
                   }
                     
                }
                //else
                //{
                //    return new APIResponse(HttpStatusCode.NotAcceptable);
                //}

                // PhotoCount
                if (serviceSubscription == null)
                {

                    foreach(var item in multidetail)
                    {
                        if (int.Parse(item.Value) >= request.Request.UtilityCount)
                        {
                            foreach (var item1 in utility)
                            {
                                if (item1.VendorId == request.Request.VendorId &&
                                    item1.ServiceSubscriptionId == request.Request.ServiceSubscriptionId &&
                                    item1.Benefit == request.Request.Benefit)
                                {
                                    var vendorSubscription = await repository.Utilitys.GetUtilityById(item1.Id);
                                    if (vendorSubscription == null)
                                    {
                                        return new APIResponse(HttpStatusCode.NotFound);
                                    }
                                      utilityRequest = mapper.Map(request.Request, vendorSubscription);
                                    repository.Utilitys.UpdateUtility(utilityRequest);
                                    await repository.SaveAsync();
                                }
                            }
                        }
                        if (utility.Count == 0)
                        {
                            foreach (var item1 in multidetail)
                            {
                                if (int.Parse(item1.Value) >= request.Request.UtilityCount)
                                {
                                    utilityRequest = mapper.Map<Vendorserviceutilisation>(request.Request);
                                    repository.Utilitys.CreateUtility(utilityRequest);
                                    await repository.SaveAsync();
                                    return new APIResponse(new UtilityIdDetails { UtilityId = utilityRequest.Id }, HttpStatusCode.Created);

                                }
                                else
                                {
                                    return new APIResponse(HttpStatusCode.NotAcceptable);
                                }
                            }
                        }
                    }          
                }

                // New DB Entry
                if (utility.Count == 0)
                {
                    if(BenefitCount+topupCount >= request.Request.UtilityCount)
                    {
                        utilityRequest = mapper.Map<Vendorserviceutilisation>(request.Request);
                        repository.Utilitys.CreateUtility(utilityRequest);
                        await repository.SaveAsync();
                    }                                 
                }

                return new APIResponse(new UtilityIdDetails { UtilityId = utilityRequest.Id }, HttpStatusCode.Created);
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
