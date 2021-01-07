using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceBenefit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface ISubscriptionBenefitService
    {
        Task<APIResponse> DeleteSubcriptionBenefit(int subcriptionbenefitId);
        Task<APIResponse> CreateSubcriptionBenefit(CreateSubscriptionBenefitRequest request);
        Task<APIResponse> GetSubcriptionPlan(int subcriptionBenefitId);
        Task<APIResponse> GetSubcriptionPlans(SubscriptionBenefitsParameter subscriptionBenefitsParameters);
        Task<APIResponse> UpdateSubcriptionBenefit(int subcriptionbenefitId, UpdateSubscriptionBenefitRequest request);
    }
}
