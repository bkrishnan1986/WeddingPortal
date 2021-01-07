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
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.DTO.Requests.TopUpBenefit;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using Happy.Weddings.Vendor.Core.DTO.Responses.Utility;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.Utility;
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
    /// Handler for getting all VendorSubscriptions
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Queries.GetAllVendorSubscriptionsQuery, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class GetAllUtilityHandler : IRequestHandler<GetAllUtilityQuery, APIResponse>
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
        public GetAllUtilityHandler(
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
        public async Task<APIResponse> Handle(GetAllUtilityQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int? vendorsutilitycount = 0;
                int? benefitCount = 0;
                int? remainingcount = 0;
                int? topupcount = 0;

                List <Subscription> subscription = new List<Subscription>();
                List<Topup> topup = new List<Topup>();
                var subscriptionBenefitsParameter = new SubscriptionBenefitsParameter();
                var topupBenefitsParameter = new TopUpBenefitParameter();
                var subscriptionBenefit = new List<SubscriptionBenefitsResponse>();
                var topupBenefit = new List<TopUpBenefitResponse>();

                subscriptionBenefitsParameter.IsForBenefit = null;
                subscriptionBenefitsParameter.IsForSingleData = null;
                subscriptionBenefitsParameter.IsForSubscription = null;
                subscriptionBenefitsParameter.ApprovalStatus = 0;

                topupBenefitsParameter.IsForBenefit = null;
                topupBenefitsParameter.IsForSingleData = null;
                topupBenefitsParameter.IsForTopUp = null;
                topupBenefitsParameter.ApprovalStatus = 0;

                var utility = await repository.Utilitys.GetAllUtility(request.SubscriptionUtilityParameters);
                foreach(var item in utility)
                {
                    vendorsutilitycount +=  item.UtilityCount;
                    if(item.ServiceSubscription != null)
                    {
                        subscription.Add(item.ServiceSubscription.SubscriptionNavigation);
                    }
                   
                    if(item.ServiceTopup != null )
                    {
                        topup.Add(item.ServiceTopup.TopUp);
                    }
                    if (item.ServiceSubscription == null)
                    {
                        var multidetail = await repository.MultiDetails.GetMultiDetailsById("PhotoCount");
                        foreach (var item1 in multidetail)
                        {
                            remainingcount = (int.Parse(item1.Value))-vendorsutilitycount;
                        }
                    }
                } 
                
                foreach (var item in subscription)
                {
                    subscriptionBenefitsParameter.Value = item.Id;
                    subscriptionBenefit = await repository.SubscriptionBenefits.GetAllSubscriptionBenefitsBySubsId(subscriptionBenefitsParameter);
                    foreach (var item1 in subscriptionBenefit)
                    {
                        if(item1.Benefit == request.SubscriptionUtilityParameters.BenefitId)
                        {
                            benefitCount += item1.Count;
                        }                    
                    }
                }

                foreach (var item in topup)
                {
                    topupBenefitsParameter.Value = item.Id;
                    topupBenefit = await repository.TopUpBenefits.GetAllTopUpBenefitsByTopupId(topupBenefitsParameter);
                    foreach (var item1 in topupBenefit)
                    {
                        if (item1.Benefit == request.SubscriptionUtilityParameters.BenefitId)
                        {
                            topupcount += item1.Count;
                        }
                    }
                }
                if(subscription.Count != 0)
                {
                    benefitCount = benefitCount + topupcount;
                    remainingcount = benefitCount - vendorsutilitycount;
                }
                    return new APIResponse(new UtilityCountResponse { RemainingCount = remainingcount }, HttpStatusCode.OK);
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
