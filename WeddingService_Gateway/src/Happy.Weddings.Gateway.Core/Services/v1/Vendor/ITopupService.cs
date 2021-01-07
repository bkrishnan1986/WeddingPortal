using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Topup;
using Happy.Weddings.Gateway.Core.DTO.Vendor.TopupBenefit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface ITopupService
    {
        Task<APIResponse> GetTopUps(TopUpParameter topupsParameters);
        Task<APIResponse> GetTopUpById(int topupId);
        Task<APIResponse> CreateTopUp(CreateTopUpRequest request);
        Task<APIResponse> UpdateTopUp(int topupId, UpdateTopUpRequest request);
        Task<APIResponse> DeleteTopUp(int topupId);
        Task<APIResponse> GetTopUpBenefits(TopUpBenefitParameter topupBenefitsParameters);
        Task<APIResponse> GetTopupBenefitById(int topupbenefitId);
        Task<APIResponse> CreateTopUpBenefit(CreateTopUpBenefitRequest request);
        Task<APIResponse> UpdateTopUpBenefit(int topupId, UpdateTopUpBenefitRequest request);
    }
}
