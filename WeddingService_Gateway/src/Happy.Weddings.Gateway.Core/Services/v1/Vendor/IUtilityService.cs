using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IUtilityService
    {
        Task<APIResponse> DeleteUtility(int utilityId);
        Task<APIResponse> CreateUtility(CreateUtilityRequest request);
        Task<APIResponse> GetUtility(int utilityId);
        Task<APIResponse> GetUtilitys(UtilityParameter utilityParameter);
        Task<APIResponse> UpdateUtility(int utilityId, UpdateUtilityRequest request);
    }
}
