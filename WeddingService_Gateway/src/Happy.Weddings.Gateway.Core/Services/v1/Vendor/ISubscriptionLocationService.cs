using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionLocation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface ISubscriptionLocationService
    {
        Task<APIResponse> DeleteSubcriptionPlan(int subscriptionLocationId);
        Task<APIResponse> GetSubcriptionLocations(SubscriptionLocationsParameter subscriptionLocationsParameter);
        Task<APIResponse> CreateSubcriptionLocation(CreateSubscriptionLocationRequest request);
        Task<APIResponse> GetSubcriptionPlan(int subscriptionLocationId);
        Task<APIResponse> UpdateSubcriptionPlan(int subscriptionLocationId, UpdateSubscriptionLocationRequest request);
    }
}
