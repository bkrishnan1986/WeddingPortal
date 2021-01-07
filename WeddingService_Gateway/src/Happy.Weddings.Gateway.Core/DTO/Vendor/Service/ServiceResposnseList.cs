using Happy.Weddings.Gateway.Core.DTO.Vendor.Service;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceSubscriptions;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Responses.Service
{
    public class ServiceResposnseList : ServiceResponse
    {
        public List<ServiceSubscriptionsResponse> Servicesubscription { get; set; }
    }
}
