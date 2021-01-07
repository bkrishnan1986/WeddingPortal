using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Budgeter;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.EventAssistant
{
    public interface IBudgeterService
    {
        Task<APIResponse> DeleteBudgeters(int budgeterId);
        Task<APIResponse> UpdateBudgeters(int budgeterId, UpdateBudgeterRequest request);
        Task<APIResponse> CreateBudgeters(CreateBudgeterRequest request);
        Task<APIResponse> GetBudgeterById(int budgeterId);
        Task<APIResponse> GetBudgeters(BudgeterParameters budgeterParameters);
    }
}
