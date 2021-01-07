using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.DTO.Identity.KYCData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Identity
{
    public interface IKYCDetailsService
    {
        Task<APIResponse> GetKYCDatas(int profileId);
        Task<APIResponse> UpdateKYCPortion(int profileId, UpdateKYCPortionRequest request);
        Task<APIResponse> UpdateKYCData(int profileId, UpdateKYCDataRequest request);
        Task<APIResponse> CreateKYCData(int profileId, CreateKYCDataRequest request);
    }
}
