using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceSubscriptions;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.Service
{
    public class ServiceResposnseList : ServiceResponse
    {
        public List<ServiceSubscriptionsResponse> Servicesubscription { get; set; }
    }
}
