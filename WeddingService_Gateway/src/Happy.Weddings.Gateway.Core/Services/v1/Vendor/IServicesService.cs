using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IServicesService
    {
        Task<APIResponse> AddService(AddServicesRequests request);
        Task<APIResponse> UpdateService(int serviceId, UpdateServiceRequest request);
        Task<APIResponse> DeleteService(int serviceId);
        Task<APIResponse> GetAllServices(ServicesParameters serviceParameters);
        Task<APIResponse> SearchServices(SearchParameters searchParameters);
        Task<APIResponse> GetServicesofVendor(string vendorId);
        Task<APIResponse> GetServiceOfferedByServiceId(int serviceId);
    }
}
