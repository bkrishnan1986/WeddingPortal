using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceTopup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IServiceTopupService
    {
        Task<APIResponse> DeleteServiceTopup(int servicetopupId);
        Task<APIResponse> UpdateServiceTopup(int servicesubscriptionId, UpdateServiceTopupRequest request);
        Task<APIResponse> CreateServiceTopup(CreateServiceTopupRequest request);
        Task<APIResponse> GetServiceTopupById(int servicetopupId);
        Task<APIResponse> GetServiceTopups(ServiceTopupParameter serviceTopupParameter);
    }
}
