using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceSubscription;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IServiceSubscriptionService
    {
        Task<APIResponse> DeleteServiceSubscription(int servicesubscriptionId);
        Task<APIResponse> UpdateVendorSubscription(int servicesubscriptionId, UpdateServiceSubscriptionRequest request);
        Task<APIResponse> CreateServiceSubscription(CreateServiceSubscriptionRequest request);
        Task<APIResponse> GetServiceSubscriptionById(int serviceSubscriptionId);
        Task<APIResponse> GetServiceSubscriptions(ServiceSubscriptionsParameter serviceSubscriptionsParameter);
    }
}
