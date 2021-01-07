using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionPlan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface ISubscriptionService
    {
        Task<APIResponse> DeleteSubcriptionPlan(int subscriptionplanId);
        Task<APIResponse> UpdateSubcriptionPlan(int subscriptionplanId, UpdateSubscriptionPlanRequest request);
        Task<APIResponse> GetSubcriptionPlan(int subscriptionPlanId);
        Task<APIResponse> GetSubcriptionPlans(SubscriptionPlansParameter subscriptionPlansParameters);
        Task<APIResponse> CreateSubcriptionPlan(CreateSubscriptionPlanRequest request);
    }
}
